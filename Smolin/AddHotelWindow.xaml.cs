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
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace Smolin
{
    /// <summary>
    /// Логика взаимодействия для AddHotelWindow.xaml
    /// </summary>
    public partial class AddHotelWindow : Window
    {
        private HotelEntities _context = new HotelEntities();
        private string _selectedCountryCode;
        private Country _selectedCountry;
        private byte[] imageHotel;
        private HotelWindow _hotelsWindow;
        public AddHotelWindow(HotelWindow hotelsWindow)
        {
            InitializeComponent();
            CmbNameCountry.ItemsSource = _context.Country.ToList();
            _hotelsWindow = hotelsWindow;
        }
        private void BtnAddHotel_Click(object sender, RoutedEventArgs e)
        {
            if (TxtCountStars.Text != "" && TxtDescHotel.Text != "" && TxtNameHotel.Text != "" && CmbNameCountry.SelectedItem != null)
            {
                foreach (Country i in _context.Country)
                {
                    if ((CmbNameCountry.SelectedItem as Country).Name == i.Name)
                    {
                        _selectedCountryCode = i.Name;
                        _selectedCountry = i;

                    }
                }
                if (Convert.ToInt32(TxtCountStars.Text) >= 0 && Convert.ToInt32(TxtCountStars.Text) <= 5)
                {
                    Hotel hotel = new Hotel()
                    {
                        CountOfStars = Convert.ToInt32(TxtCountStars.Text),
                        Name = TxtNameHotel.Text,
                        CountryCode = _selectedCountryCode,
                        Country = _selectedCountry,
                        Description = TxtDescHotel.Text
                    };
                    if (this.imageHotel != null)
                    {
                        hotel.HotelImage.Add(new HotelImage()
                        {
                            ImageSource = this.imageHotel,
                            Hotel = hotel,
                            HotelId = hotel.Id
                        });

                    }
                    _context.Hotel.Add(hotel);
                    _context.SaveChanges();

                }
                else
                {
                    MessageBox.Show("Введено некорректное число (должно быть от 0 до 5!)");
                    return;


                }
                _hotelsWindow.DataGridHotels.ItemsSource =_context.Hotel.OrderBy(h => h.Name).ToList();
                _hotelsWindow.RefreshHotels();
                this.Hide();

            }

            else
            {
                MessageBox.Show("Не все поля формы заполнены!");

            }
        }
        private void Overview_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            string path;
            if (openFileDialog.ShowDialog() == true)
            {
               
                path = openFileDialog.FileName;
                this.imageHotel = System.IO.File.ReadAllBytes(path);
                ImgHotel.Source = new BitmapImage(new Uri(path));

            }
        }
    }
}
