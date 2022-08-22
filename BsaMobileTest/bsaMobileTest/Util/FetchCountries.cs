using BsaMobileTest.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection; 

namespace BsaMobileTest.Util
{
    public static class FetchCountries
    {
        public static List<Country> Countries => JsonConvert.DeserializeObject<List<Country>>(
            new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("BsaMobileTest.Util.countries_states_cities.json")).ReadToEnd());   
            
        public static Country Country => Countries.FirstOrDefault(x => x.id == 31);
        
        public static List<City> GetCities(string name) => Country?.states.FirstOrDefault(x => x.name == name).cities;

        public static List<State> GetStates(string name) => Countries?.FirstOrDefault(x => x.name == name).states;
    }
}
