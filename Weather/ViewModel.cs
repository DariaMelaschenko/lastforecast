using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Weather.Mediator;
using Windows.UI.Xaml.Media.Imaging;

namespace Weather.Logic
{
    public class ViewModel : MyPropertyChanged
    {
        mediator _mediator = mediator.Instance;

        public WeatherNow weather_now;
        public WeatherForecast weather_forecast;
        
        #region BindedVariables
        private string _city;
        private string _country;
        private string _updated;
        private string _units;

        private BitmapImage _selected_picture;
        private string _selected_date;
        private string _selected_description;

        private float _selected_temp_day;
        private float _selected_temp_night;

        private float _selected_temp_max;
        private float _selected_temp_min;

        private float _selected_pressure;
        private int _selected_humidity;

        private float _selected_wind_speed;
        private int _selected_clouds;
        #endregion
        
        #region properties
        public string city
        {
            get {return _city;}
            set {_city = value; Notify();}
        }

        public string country
        {
            get { return _country; }
            set { _country = value; Notify(); }
        }

        public string updated
        {
            get { return _updated; }
            set { _updated = value; Notify(); }
        }

        public string units
        {
            get { return _units; }
            set { _units = value; Notify(); }
        }

        public BitmapImage selected_picture
        {
            get { return _selected_picture; }
            set { _selected_picture = value; Notify(); }
        }

        public string selected_date
        {
            get { return _selected_date; }
            set { _selected_date = value; Notify(); }
        }

        public string selected_description
        {
            get { return _selected_description; }
            set { _selected_description = value; Notify(); }
        }

        public float selected_temp_max
        {
            get { return _selected_temp_max; }
            set { _selected_temp_max = value; Notify(); }
        }

        public float selected_temp_min
        {
            get { return _selected_temp_min; }
            set { _selected_temp_min = value; Notify(); }
        }

        public float selected_temp_day
        {
            get { return _selected_temp_day; }
            set { _selected_temp_day = value; Notify(); }
        }

        public float selected_temp_night
        {
            get { return _selected_temp_night; }
            set { _selected_temp_night = value; Notify(); }
        }

        public float selected_pressure
        {
            get { return _selected_pressure; }
            set { _selected_pressure = value; Notify(); }
        }

        public int selected_humidity
        {
            get { return _selected_humidity; }
            set { _selected_humidity = value; Notify(); }
        }

        public float selected_wind_speed
        {
            get { return _selected_wind_speed; }
            set { _selected_wind_speed = value; Notify(); }
        }

        public int selected_clouds
        {
            get { return _selected_clouds; }
            set { _selected_clouds = value; Notify(); }
        }

        #endregion

        public ObservableCollection<WeatherNotToday> forecast = new ObservableCollection<WeatherNotToday>();
        
        public async Task GetData()
        {
            using (var http = new HttpClient())
            {
                var json = await http.GetStringAsync(_mediator.InquiryWeather);
                //var json = "{\"coord\":{\"lon\":30.52,\"lat\":50.43},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"base\":\"stations\",\"main\":{\"temp\":-3,\"pressure\":1028,\"humidity\":73,\"temp_min\":-3,\"temp_max\":-3},\"visibility\":10000,\"wind\":{\"speed\":3,\"deg\":260},\"clouds\":{\"all\":0},\"dt\":1458104400,\"sys\":{\"type\":1,\"id\":7358,\"message\":0.0316,\"country\":\"UA\",\"sunrise\":1458101304,\"sunset\":1458144315},\"id\":703448,\"name\":\"Kiev\",\"cod\":200}";
                weather_now = JsonConvert.DeserializeObject<WeatherNow>(json);

                json = await http.GetStringAsync(_mediator.InquiryForecast);
                //json = "{\"city\":{\"id\":703448,\"name\":\"Kiev\",\"coord\":{\"lon\":30.516666,\"lat\":50.433334},\"country\":\"UA\",\"population\":0},\"cod\":\"200\",\"message\":0.0632,\"cnt\":7,\"list\":[{\"dt\":1458122400,\"temp\":{\"day\":5.85,\"min\":-3,\"max\":6.58,\"night\":3.13,\"eve\":5.81,\"morn\":-3},\"pressure\":1025.35,\"humidity\":69,\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"speed\":4.36,\"deg\":323,\"clouds\":12},{\"dt\":1458208800,\"temp\":{\"day\":4.9,\"min\":3.43,\"max\":6.07,\"night\":4.4,\"eve\":5.49,\"morn\":3.43},\"pressure\":1014.87,\"humidity\":86,\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"speed\":7.02,\"deg\":309,\"clouds\":88,\"rain\":0.45},{\"dt\":1458295200,\"temp\":{\"day\":6.09,\"min\":1.56,\"max\":6.4,\"night\":1.56,\"eve\":5.67,\"morn\":4.05},\"pressure\":1002.78,\"humidity\":83,\"weather\":[{\"id\":600,\"main\":\"Snow\",\"description\":\"light snow\",\"icon\":\"13d\"}],\"speed\":9.16,\"deg\":296,\"clouds\":80,\"rain\":0.8,\"snow\":0.03},{\"dt\":1458381600,\"temp\":{\"day\":6.14,\"min\":-2.96,\"max\":6.14,\"night\":-2.96,\"eve\":2.93,\"morn\":4.22},\"pressure\":1000.26,\"humidity\":0,\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"speed\":8,\"deg\":284,\"clouds\":63,\"rain\":2.99},{\"dt\":1458468000,\"temp\":{\"day\":-0.67,\"min\":-5.4,\"max\":-0.67,\"night\":-5.4,\"eve\":-3.93,\"morn\":-2.89},\"pressure\":1008.76,\"humidity\":0,\"weather\":[{\"id\":600,\"main\":\"Snow\",\"description\":\"light snow\",\"icon\":\"13d\"}],\"speed\":6.61,\"deg\":325,\"clouds\":63,\"snow\":0.05},{\"dt\":1458554400,\"temp\":{\"day\":3.3,\"min\":-2.87,\"max\":3.3,\"night\":1.52,\"eve\":-0.64,\"morn\":-2.87},\"pressure\":1012.75,\"humidity\":0,\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"speed\":5.28,\"deg\":297,\"clouds\":15,\"rain\":0.36,\"snow\":0.01},{\"dt\":1458640800,\"temp\":{\"day\":7.94,\"min\":-0.55,\"max\":7.94,\"night\":-0.55,\"eve\":2.84,\"morn\":4.24},\"pressure\":1006.27,\"humidity\":0,\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"speed\":5.87,\"deg\":289,\"clouds\":41,\"rain\":2.5}]}";
                weather_forecast = JsonConvert.DeserializeObject<WeatherForecast>(json);
            }
            _mediator.Update(weather_now);
        }

        public void initForecasteAndInformation()
        {
            city = _mediator.city;
            country = _mediator.country;
            updated = weather_now.Time;

            units = _mediator.units;
             
            forecast.Clear();
            foreach (WeatherNotToday x in weather_forecast.list)
                forecast.Add(x);
        }

        public void initToday()
        {
            selected_temp_day = weather_now.main.temp;
            
            selected_picture = weather_now.icon;
            selected_date = weather_now.Date;
            selected_description = weather_now.description;

            selected_temp_max = weather_now.main.temp_max;
            selected_temp_min = weather_now.main.temp_min;

            selected_pressure = weather_now.main.pressure;
            selected_humidity = weather_now.main.humidity;

            selected_wind_speed = weather_now.wind.speed;
            selected_clouds = weather_now.clouds.all;
        }

        public void initNotToday(WeatherNotToday wnt)
        {
            selected_picture = wnt.icon;
            selected_date = wnt.Date;
            selected_description = wnt.description;

            selected_temp_day = wnt.temp.day;
            selected_temp_night = wnt.temp.night;

            selected_temp_max = wnt.temp.max;
            selected_temp_min = wnt.temp.min;

            selected_pressure = wnt.pressure;
            selected_humidity = wnt.humidity;

            selected_wind_speed = wnt.speed;
            selected_clouds = wnt.clouds;
        }
    }
}
