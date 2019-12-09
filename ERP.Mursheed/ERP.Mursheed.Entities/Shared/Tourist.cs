using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.Mursheed.Entities.Shared
{
    public class Tourist
    {
        public Tourist()
        {
            DriverRides = new HashSet<DriverRide>();
            GuideRides = new HashSet<GuideRide>();
        }
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int CountryId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string AdditionalInfo { get; set; }
        public string Fullname => $"{Firstname} {Lastname}";

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<DriverRide> DriverRides { get; set; }
        public virtual ICollection<GuideRide> GuideRides { get; set; }
    }
}
