using System;
using System.Collections.Generic;
using System.Text;

namespace BsaMobileTest.Models
{
    public class State
    {
        public int id { get; set; }
        public string name { get; set; }
        public string state_code { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string type { get; set; }
        public List<City> cities { get; set; }
    }
}
