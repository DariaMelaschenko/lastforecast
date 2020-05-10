using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Weather.Logic;

namespace Weather.Mediator
{
    public class mediator
    {
        private static mediator instance = new mediator();

        public static mediator Instance
        {
            get { return instance; }
        }
        
        private mediator()
        {}

        private Location where;
        private settings UserSettings = new settings();

        public bool[] RadioButtons
        { get { return UserSettings._RadioButtons; } set { UserSettings._RadioButtons = value; } }

        public bool isNotLocated
        { get { return where == null; } }

        public string city
        { get { return where.city.name_en; } set { where.city.name_en = value; } }

        public string country
        { get { return where.country.iso; } set { where.country.iso = value; } }

        public int city_id
        { get { return where.city.id; } set { where.city.id = value; } }

        public string units
        {
            get
            {
                if (UserSettings._units.Equals("&units=metric")) return "C";
                else if (UserSettings._units.Equals("&units=imperial")) return "F";
                else return "K";
            }

            set
            {
                UserSettings._units = value;
            }
        }

        #region InquiryType
        public string GetWeatherByCityName
        {
            get
            {
                return "http://api.openweathermap.org/data/2.5/weather?q="
                    + where.city.name_en + UserSettings.mode + UserSettings._units + UserSettings.AppID;
            }
        }

        public string GetWeatherByCityAndCountryName
        {
            get
            {
                return "http://api.openweathermap.org/data/2.5/weather?q="
                    + where.city.name_en + "," + where.country.iso + UserSettings.mode + UserSettings._units + UserSettings.AppID;
            }
        }

        public string GetWeatherByCityId
        {
            get
            {
                return "http://api.openweathermap.org/data/2.5/weather?id="
                   + where.city.id + UserSettings.mode + UserSettings._units + UserSettings.AppID;
            }
        }

        public string GetForecastByCityName
        {
            get
            {
                return "http://api.openweathermap.org/data/2.5/forecast/daily?q="
                    + where.city.name_en + UserSettings.mode + UserSettings._units + "&cnt=" + UserSettings.days + UserSettings.AppID;
            }
        }

        public string GetForecastByCityAndCountryName
        {
            get
            {
                return "http://api.openweathermap.org/data/2.5/forecast/daily?q="
                    + where.city.name_en + "," + where.country.iso + UserSettings.mode + UserSettings._units + "&cnt=" + UserSettings.days + UserSettings.AppID;
            }
        }

        public string GetForecastByCityId
        {
            get
            {
                return "http://api.openweathermap.org/data/2.5/forecast/daily?id="
                    + where.city.id + UserSettings.mode + UserSettings._units + "&cnt=" + UserSettings.days + UserSettings.AppID;
            }
        }
        #endregion

        #region Inquiry
        public string InquiryWeather
        {
            get
            {
                if (RadioButtons[3]) return GetWeatherByCityName;
                else if (RadioButtons[4]) return GetWeatherByCityAndCountryName;
                else return GetWeatherByCityId;
            }
        }

        public string InquiryForecast
        {
            get
            {
                if (RadioButtons[3]) return GetForecastByCityName;
                else if (RadioButtons[4]) return GetForecastByCityAndCountryName;
                else return GetForecastByCityId;
            }
        }
        #endregion

        public void Update(WeatherNow wn)
        {
            city = wn.name;
            country = wn.sys.country;
            city_id = wn.id;
        }

        async public Task WhereIsMyMind()
        {
            using (var http = new HttpClient())
            {
                var json = await http.GetStringAsync("http://api.sypexgeo.net/");
                //var json = "{\"ip\":\"77.47.204.228\",\"city\":{\"id\":703448,\"lat\":50.45466,\"lon\":30.5238,\"name_ru\":\"Киев\",\"name_en\":\"Kiev\",\"name_de\":\"Kiew\",\"name_fr\":\"Kiev\",\"name_it\":\"Kiev\",\"name_es\":\"Kiev\",\"name_pt\":\"Kiev\",\"okato\":\"80\",\"vk\":314,\"population\":2797553},\"region\":{\"id\":703447,\"lat\":50.43,\"lon\":30.52,\"name_ru\":\"Киев\",\"name_en\":\"Kyiv\",\"name_de\":\"Kiew\",\"name_fr\":\"Kiev\",\"name_it\":\"Kiev\",\"name_es\":\"Kiev\",\"name_pt\":\"Kiev\",\"iso\":\"UA-30\",\"timezone\":\"Europe/Kiev\",\"okato\":\"80\",\"auto\":\"AA, КА, 11\",\"vk\":0,\"utc\":2},\"country\":{\"id\":222,\"iso\":\"UA\",\"continent\":\"EU\",\"lat\":49,\"lon\":32,\"name_ru\":\"Украина\",\"name_en\":\"Ukraine\",\"name_de\":\"Ukraine\",\"name_fr\":\"Ukraine\",\"name_it\":\"Ucraina\",\"name_es\":\"Ucrania\",\"name_pt\":\"Ucrânia\",\"timezone\":\"Europe/Kiev\",\"area\":603700,\"population\":45415596,\"capital_id\":703448,\"capital_ru\":\"Киев\",\"capital_en\":\"Kiev\",\"cur_code\":\"UAH\",\"phone\":\"380\",\"neighbours\":\"PL,MD,HU,SK,BY,RO,RU\",\"vk\":2,\"utc\":2},\"error\":\"\",\"request\":-1,\"created\":\"2016.03.11\",\"timestamp\":1457655885}";
                where = JsonConvert.DeserializeObject<Location>(json);
            }
        }
    }
}
