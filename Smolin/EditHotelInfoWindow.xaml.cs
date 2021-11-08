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
using Microsoft.Win32;

namespace Smolin
{

    public partial class EditHotelInfoWindow : Window
    {
        private HotelEntities _context;
        private Hotel _hotel;
        private HotelWindow _hotelsWindow;
        private byte[] imageHotel;
        List<HotelImage> hotelImages;
        int _currentPage = 1;
        int _maxImages = 0;
        public EditHotelInfoWindow(object o, HotelEntities hotelentities, HotelWindow hotelsWindow)
        {
            InitializeComponent();
            _hotel = (o as Button).DataContext as Hotel;
            DataContext = _hotel.HotelImage;
            _maxImages = _hotel.HotelImage.ToList().Count;
            this.hotelImages = _hotel.HotelImage.ToList();
            _context = hotelentities;
            _hotelsWindow = hotelsWindow;
            CmbNameCountry.ItemsSource = _context.Country.ToList();
            InsertHotelInfo();
        }
        private void InsertHotelInfo()
        {

            TxtNameHotel.Text = _hotel.Name;
            TxtCountStars.Text = Convert.ToString(_hotel.CountOfStars);
            CmbNameCountry.SelectedItem = _hotel.Country;
        }
        private void BtnDeleteHotel_Click(object sender, RoutedEventArgs e)
        {
            _context.Hotel.Remove(_hotel);
            _context.SaveChanges();
            _hotelsWindow.DataGridHotels.ItemsSource =_context.Hotel.ToList();
            _hotelsWindow.RefreshHotels();
            this.Close();
        }
        private void BtnUpadateHotelInfo_Click(object sender,RoutedEventArgs e)
        {
            UpdateHotelProperty();
            _hotelsWindow.RefreshHotels();
            _context.SaveChanges();
            this.Close();
        }
        private void UpdateHotelProperty()
        {
            _hotel.Name = TxtNameHotel.Text;
            _hotel.CountOfStars = Convert.ToInt32(TxtCountStars.Text);
            _hotel.Country = CmbNameCountry.SelectedItem as Country;
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
            try
            {
                _hotel.HotelImage.Add(new HotelImage()
                {
                    Hotel = _hotel,
                    HotelId = _hotel.Id,
                    ImageSource = this.imageHotel
                });
                _context.SaveChanges();
                MessageBox.Show("Картинка успешно добавлена!");
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }
        }
        private void PrevImg_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage - 1 < 1)
            {
                return;

            }
            _currentPage--;
            this.hotelImages = this.hotelImages.Skip(_currentPage -1).Take(1).ToList();
            DataContext = this.hotelImages;
            this.hotelImages = _hotel.HotelImage.ToList();

        }
        private void NextImg_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage + 1 > _maxImages)
            {
                return;

            }
            _currentPage++;
            this.hotelImages = this.hotelImages.Skip(_currentPage -1).Take(1).ToList();
            DataContext = this.hotelImages;
            this.hotelImages = _hotel.HotelImage.ToList();
        }
    }
}
