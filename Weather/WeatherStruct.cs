using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Weather.Logic
{

    #region json_fields

    public class s_sys
    {
        [JsonProperty("country")]
        public string country { get; set; }
    }

    public class s_temperature
    {
        [JsonProperty("day")]
        public float day { get; set; }

        [JsonProperty("night")]
        public float night { get; set; }

        [JsonProperty("min")]
        public float min { get; set; }

        [JsonProperty("max")]
        public float max { get; set; }
    }

    public class s_main_now
    {
        [JsonProperty("humidity")]
        public int humidity { get; set; }

        [JsonProperty("pressure")]
        public float pressure { get; set; }

        [JsonProperty("temp")]
        public float temp { get; set; }

        [JsonProperty("temp_min")]
        public float temp_min { get; set; }

        [JsonProperty("temp_max")]
        public float temp_max { get; set; }
    }

    public class s_wind
    {
        [JsonProperty("speed")]
        public float speed { get; set; }
    }

    public class s_clouds
    {
        [JsonProperty("all")]
        public int all { get; set; }
    }

    public class s_weather_element
    {
        [JsonProperty("main")]
        public string main { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("icon")]
        public string icon { get; set; }
    }
    
    #endregion

    #region result
    
    public class WeatherBase
    {
        [JsonProperty("weather")]
        public List<s_weather_element> weather { get; set; }

        private long _dt;

        [JsonProperty("dt")]
        public long dt
        {
            get { return _dt; }
            set
            {
                _dt = value;
                ddt = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                ddt = ddt.AddSeconds(_dt).ToLocalTime();
            }
        }

        public BitmapImage icon
        { get { return new BitmapImage(new Uri($"http://openweathermap.org/img/w/{weather[0].icon}.png")); } }

        public string weather_main
        { get { return weather[0].main; } }

        public string description
        { get { return weather[0].description; } }

        public DateTime ddt;
        
        public string Date
        { get { return ddt.ToString("D"); } }

        public string Day
        { get { return $"{ddt.DayOfWeek} {ddt.Day}"; } }

        public string Time
        { get { return $"{ddt.Hour:D2}:{ddt.Minute:D2}"; } }
    }

    public class WeatherNotToday : WeatherBase
    {
        [JsonProperty("temp")]
        public s_temperature temp { get; set; }

        [JsonProperty("humidity")]
        public int humidity { get; set; }

        [JsonProperty("pressure")]
        public float pressure { get; set; }

        [JsonProperty("speed")]
        public float speed { get; set; }

        [JsonProperty("clouds")]
        public int clouds { get; set; }
    }

    public class WeatherNow : WeatherBase
    {
        [JsonProperty("sys")]
        public s_sys sys { set; get; }


        [JsonProperty("main")]
        public s_main_now main { set; get; }

        [JsonProperty("wind")]
        public s_wind wind { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
        
        [JsonProperty("clouds")]
        public s_clouds clouds { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }
    }

    public class WeatherForecast 
    {
        [JsonProperty("list")]
        public LinkedList<WeatherNotToday> list { get; set; }
    }

    #endregion
}
