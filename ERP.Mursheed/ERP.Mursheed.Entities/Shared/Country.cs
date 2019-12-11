using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.Mursheed.Entities.Shared
{
    public class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            Tourists = new HashSet<Tourist>();
            Guides = new HashSet<Guide>();
        }
        [Key]public int Id { get; set; }
        public string ISO { get; set; }
        public string Name { get; set; }
        public string NiceName { get; set; }
        public string ISO3 { get; set; }
        public string NumCode { get; set; }
        public string PhoneCode { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Tourist> Tourists { get; set; }
        public virtual ICollection<Guide> Guides { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }

    public class City
    {
        public City()
        {
            
        }
        [Key] public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string NiceName { get; set; }

        public Country Country { get; set; }
        public virtual ICollection<Route> FromRoutes { get; set; }
        public virtual ICollection<Route> ToRoutes { get; set; }
    }
}
