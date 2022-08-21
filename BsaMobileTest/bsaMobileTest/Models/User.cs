using SQLite;
using System; 

namespace bsaMobileTest.Models
{ 
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        [NotNull, Unique]
        public string Email { get; set; }
        [NotNull, Unique]
        public string Username { get; set; }
        [NotNull]
        public string Password { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; } 
        public string CityCode { get; set; }
        public string CountryCode { get; set; }
        public DateTime Birth { get; set; }

    }
}
