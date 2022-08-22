using System;
using System.Collections.Generic;
using System.Text;

namespace BsaMobileTest.Models
{
    public class Country 
    {
        public int id { get; set; }
        public string name { get; set; }
        public string iso3 { get; set; }
        public string iso2 { get; set; }
        public string numeric_code { get; set; }
        public string phone_code { get; set; }
        public string capital { get; set; }
        public string currency { get; set; }
        public string currency_name { get; set; }
        public string currency_symbol { get; set; }
        public string tld { get; set; }
        public string native { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public List<Timezone> timezones { get; set; }
        public List<KeyValuePair<string,string>> translations { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string emoji { get; set; }
        public string emojiU { get; set; }
        public List<State> states { get; set; }
    }

    public class Timezone
    {
        public string zoneName { get; set; }
        public int gmtOffset { get; set; }
        public string gmtOffsetName { get; set; }
        public string abbreviation { get; set; }
        public string tzName { get; set; }
    }
}
