using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Smolin
{
    
    public partial class MainWindow : Window
    {
        private HotelEntities _context = new HotelEntities();
        private List<Tour> _tours = new List<Tour>();
        private string _SelectedType = "";
        private string _FindedName = "";
    

        public MainWindow()
        {
            InitializeComponent();
            
            
            ListTours.ItemsSource = _context.Tour.OrderBy(tour => tour.Name).ToList();
            CmbTypes.ItemsSource = _context.Type.OrderBy(types => types.Name).ToList();
            this._tours = _context.Tour.ToList();

        }
        public void RefreshTours()
        {
            if (CmbTypes.SelectedItem != null)
            {
                _tours = (from t in _tours from tn in t.Type where tn.Name == _SelectedType select t).ToList();

            }
            if (TxtFindedTourName.Text != "")
            {
                _tours = _tours.OrderBy(tour => tour.Name).Where(t => t.Name.ToLower().Contains(TxtFindedTourName.Text)).ToList();
            }
            if ((bool)ChbActual.IsChecked)
            {
                _tours = _tours.OrderBy(tour => tour.Name).Where(tour => tour.IsActual).ToList();

            }
            ListTours.ItemsSource = _tours;

        }

        private void TxtFindedTourName_TextChanged(object sender, TextChangedEventArgs e)
        {
            this._tours = _context.Tour.ToList();
            this._FindedName = TxtFindedTourName.Text.ToLower();
            RefreshTours();
          
        }

        private void CmbTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _tours = _context.Tour.ToList();
            Type type = CmbTypes.SelectedItem as Type;
            _SelectedType = type.Name;
            RefreshTours();
        }

        private void ChbActual_Checked(object sender, RoutedEventArgs e)
        {
            this._tours = _context.Tour.ToList();
            RefreshTours();
        }

        private void ChbActual_Unchecked(object sender, RoutedEventArgs e)
        {
            this._tours = _context.Tour.ToList();
            RefreshTours();
        }

        private void BtnListHotelsView_Click(object sender, RoutedEventArgs e)
        {
            HotelWindow hotelsWindow = new HotelWindow();
            hotelsWindow.Show();

        }

        private void ListTours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
