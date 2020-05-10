using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Mediator
{
    public class area_city
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name_en")]
        public string name_en { get; set; }
    }

    public class area_country
    {
        [JsonProperty("name_en")]
        public string name_en { get; set; }

        [JsonProperty("iso")]
        public string iso { get; set; }
    }

    public class Location
    {
        [JsonProperty("city")]
        public area_city city { get; set; }

        [JsonProperty("country")]
        public area_country country { get; set; }
    }
}
