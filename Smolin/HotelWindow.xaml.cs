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
    
   
    public partial class HotelWindow : Window
    {
        private HotelEntities _context = new HotelEntities();
        private int _currentPage = 1;
        private int _maxPage = 0;
        public HotelWindow()
        {
            this.RemoveHandler(KeyDownEvent, new KeyEventHandler(Window_KeyDown));
            this.AddHandler(KeyDownEvent, new KeyEventHandler(Window_KeyDown), true);

            InitializeComponent();
            RefreshHotels();
            

        }
        public bool RefreshHotels()
        {
            try
            {
                DataGridHotels.ItemsSource = _context.Hotel.ToList();
                _maxPage = Convert.ToInt32(Math.Ceiling(_context.Hotel.ToList().Count * 1.0 / 10));
                var listHotels = _context.Hotel.ToList().Skip((_currentPage - 1) * 10).Take(10).ToList();
                LblTotalPages.Content = "of " + _maxPage.ToString();
                TxtCurrentPageNumber.Text = _currentPage.ToString();
                DataGridHotels.ItemsSource = listHotels;
                TxtCountRecords.Text = "Количество записей: " + _context.Hotel.ToList().Count.ToString() + " ";
                TxtCountRecordsInCurrentPage.Text = "Количество записей в текущей странице: " + listHotels.Count.ToString() + " ";
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void BtnEditHotelInfo_Click(object sender, RoutedEventArgs e)
        {
            EditHotelInfoWindow editHotelInfoWindow = new
            EditHotelInfoWindow(sender, _context, this);
            editHotelInfoWindow.Show();
        }

        private void GoLastPageButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = _maxPage;
            RefreshHotels();
        }
        private void GoNextPageButton_Click(object sender,RoutedEventArgs e)
        {
            if (_currentPage + 1 > _maxPage)
            {
                return;

            }
            _currentPage++;
            RefreshHotels();

        }
        private void GoPrevPageButton_Click(object sender,RoutedEventArgs e)
        {
            if (_currentPage - 1 < 1)
            {
                return;

            }
            _currentPage--;
            RefreshHotels();

        }
        private void BtnAddHotel_Click(object sender, RoutedEventArgs e)
        {
            AddHotelWindow addHotelWindow = new AddHotelWindow(this);
            addHotelWindow.Show();

        }
        private void TxtCurrentPageNumber_TextChanged(object sender,TextChangedEventArgs e)
        {
            if (_currentPage > 0 && _currentPage <= _maxPage)
            {
                _currentPage = Convert.ToInt32(TxtCurrentPageNumber.Text);
                RefreshHotels();

            }


        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var deletedHotels = DataGridHotels.SelectedItems.Cast<Hotel>().ToList();
                string deletedHotelsInfo = "";
                foreach (var item in deletedHotels)
                {
                    deletedHotelsInfo += item.Name + ", ";

                }
                MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить " + deletedHotels, "", MessageBoxButton.OKCancel);
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    _context.Hotel.RemoveRange(deletedHotels);
                    _context.SaveChanges();
                }
                else if (messageBoxResult == MessageBoxResult.Cancel)
                {
                    return;
                }
                RefreshHotels();
                e.Handled = true;
            }

        }

        private void GoFirstPageButton_Click(object sender, RoutedEventArgs e)
        {
           
            _currentPage = 1;
            RefreshHotels();
        }
    }
}
