using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
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

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Weather
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        ViewModel ViewModel = new ViewModel();
        mediator _mediator = mediator.Instance;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Settings));
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_mediator.isNotLocated) await _mediator.WhereIsMyMind();

            await ViewModel.GetData();
            ViewModel.initForecasteAndInformation();
            ViewModel.initToday();
            Window.Visibility = Visibility.Visible;
        }

        private async void appBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetData();
            ViewModel.initForecasteAndInformation();
            ViewModel.initToday();
        }

        private void Forecast_ItemClick(object sender, ItemClickEventArgs e)
        {

            var wnt = e.ClickedItem as WeatherNotToday;
            if (wnt != null)
                if (wnt.Date.Equals(ViewModel.weather_now.Date))
                {
                    Temp_night.Visibility = Visibility.Collapsed;
                    ViewModel.initToday();
                }
                else
                {
                    ViewModel.initNotToday(wnt);
                    Temp_night.Visibility = Visibility.Visible;
                }
        }
    }
}
