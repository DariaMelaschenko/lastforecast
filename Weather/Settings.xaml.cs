using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Weather.Logic;
using Weather.Mediator;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace Weather
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Settings : Page
    {

        public mediator _mediator = mediator.Instance;

        public Settings()
        {
            this.InitializeComponent();
            MyInit();
        }

        private void MyInit()
        {
            CityBox.Text = _mediator.city;
            CityBox2.Text = _mediator.city;
            CountryBox.Text = _mediator.country;
            CityIDBox.Text = $"{_mediator.city_id}";
            
            Fahrenheit.IsChecked = _mediator.RadioButtons[0];
            Celsius.IsChecked = _mediator.RadioButtons[1];
            Kelvin.IsChecked = _mediator.RadioButtons[2];
            City.IsChecked = _mediator.RadioButtons[3];
            CityAndCountry.IsChecked = _mediator.RadioButtons[4];
            CityId.IsChecked = _mediator.RadioButtons[5];
            CurrentLocation.IsChecked = _mediator.RadioButtons[6];
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            _mediator.RadioButtons[0] = (bool)Fahrenheit.IsChecked;
            _mediator.RadioButtons[1] = (bool)Celsius.IsChecked;
            _mediator.RadioButtons[2] = (bool)Kelvin.IsChecked;
            _mediator.RadioButtons[3] = (bool)City.IsChecked;
            _mediator.RadioButtons[4] = (bool)CityAndCountry.IsChecked;
            _mediator.RadioButtons[5] = (bool)CityId.IsChecked;
            _mediator.RadioButtons[6] = (bool)CurrentLocation.IsChecked;

            if (_mediator.RadioButtons[0]) _mediator.units = "&units=imperial";
            else if (_mediator.RadioButtons[1]) _mediator.units = "&units=metric";
            else _mediator.units = "";

            if (!_mediator.RadioButtons[6])
            {
                if (_mediator.RadioButtons[3]) _mediator.city = CityBox.Text;
                else _mediator.city = CityBox2.Text;

                _mediator.country = CountryBox.Text;
                _mediator.city_id = Convert.ToInt32(CityIDBox.Text);
            }

            Frame.Navigate(typeof(MainPage));
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ByCityAndCountry.Visibility = Visibility.Collapsed;
            ByCityID.Visibility = Visibility.Collapsed;
            ByCity.Visibility = Visibility.Visible;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            ByCity.Visibility = Visibility.Collapsed;       
            ByCityID.Visibility = Visibility.Collapsed;
            ByCityAndCountry.Visibility = Visibility.Visible;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            ByCity.Visibility = Visibility.Collapsed;
            ByCityAndCountry.Visibility = Visibility.Collapsed;   
            ByCityID.Visibility = Visibility.Visible;
        }

        async private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            if (ByCity != null) ByCity.Visibility = Visibility.Collapsed;
            if (ByCityAndCountry != null) ByCityAndCountry.Visibility = Visibility.Collapsed;
            if (ByCityID != null) ByCityID.Visibility = Visibility.Collapsed;

            await _mediator.WhereIsMyMind();
        }
    }
}
