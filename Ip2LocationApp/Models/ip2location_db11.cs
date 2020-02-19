using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ip2LocationApp.Models
{
    public class ip2location_db11
    {
        public int Id { get; set; }
        public float ip_from {get; set;}

        public float ip_to {get; set;}

        public string country_code {get; set;}

        public string country_name {get; set;}

        public string region_name {get; set;}

        public string city_name {get; set;}

        public float latitude {get; set;}

        public float longitude {get; set;}

        public string zip_code {get; set;}

        public string time_zone {get; set;}
    }
}
