using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP.Mursheed.Entities.Shared
{
    public class Driver
    {
        public Driver()
        {
            DriverLanguages = new HashSet<DriverLanguage>();
            DriverRatings = new HashSet<DriverRating>();
            DriverRoutes = new HashSet<DriverRoute>();
            DriverRides = new HashSet<DriverRide>();
        }
        public int Id { get; set; }
        public string CustomId { get; set; }
        public int GovernmentalId { get; set; }
        public string DriverLicenseId { get; set; }
        public int CountryId { get; set; }
        public int CarId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname => $"{Firstname} {Lastname}";
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoName { get; set; }
        public string PhotoPath { get; set; }
        public bool Status { get; set; }

        public Country Country { get; set; }
        public Car Car { get; set; }
        public virtual ICollection<DriverLanguage>  DriverLanguages { get; set; }
        public virtual ICollection<DriverRating>  DriverRatings { get; set; }
        public virtual ICollection<DriverRoute>  DriverRoutes { get; set; }
        public virtual ICollection<DriverRide>  DriverRides { get; set; }

    }

    
    public class DriverRating
    {
        public int Id { get; set; }
        public int TouristId { get; set; }
        public int DriverId { get; set; }

        public Tourist Tourist { get; set; }
        public Driver Driver { get; set; }
    }


    public class DriverRide
    {
        public DriverRide()
        {
            DriverRideToRoutes = new HashSet<DriverRideToRoute>();
            DriverTickets = new HashSet<DriverTicket>();
        }
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int TouristId { get; set; }

        public virtual Driver  Driver { get; set; }
        public virtual Tourist  Tourist { get; set; }
        public virtual ICollection<DriverRideToRoute> DriverRideToRoutes { get; set; }
        public virtual ICollection<DriverTicket> DriverTickets { get; set; }
    }

    public class DriverRideToRoute
    {
        public int Id { get; set; }
        public int DriverRideId { get; set; }
        public int RouteId { get; set; }
        public int FromToDateId { get; set; }

        public virtual DriverRide DriverRide { get; set; }
        public virtual Route Route { get; set; }
        public virtual FromToDate FromToDate { get; set; }
    }

    public class DriverTicket
    {
        public int Id { get; set; }
        public int DriverRideId { get; set; }
        public float TotalPrice { get; set; }
        public virtual DriverRide DriverRide { get; set; }
    }


}
