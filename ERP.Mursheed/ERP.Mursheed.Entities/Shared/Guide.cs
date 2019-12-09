using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Mursheed.Entities.Shared
{
    public class Guide
    {
        public Guide()
        {
            GuideLanguages = new HashSet<GuideLanguage>();
            GuideRatings = new HashSet<GuideRating>();
            GuideRoutes = new HashSet<GuideRoute>();
            GuideRides = new HashSet<GuideRide>();
        }
        public int Id { get; set; }
        public int GovernmentalId { get; set; }
        public int CountryId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname => $"{Firstname} {Lastname}";
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoName { get; set; }
        public string PhotoPath { get; set; }
        public bool Status { get; set; }

        public Country Country { get; set; }
        public virtual ICollection<GuideLanguage> GuideLanguages { get; set; }
        public virtual ICollection<GuideRating> GuideRatings { get; set; }
        public virtual ICollection<GuideRoute> GuideRoutes { get; set; }
        public virtual ICollection<GuideRide> GuideRides { get; set; }
    }

    public class GuideRating
    {
        public int Id { get; set; }
        public int TouristId { get; set; }
        public int GuideId { get; set; }

        public Tourist Tourist { get; set; }
        public Guide Guide { get; set; }
    }

    public class GuideRide
    {
        public GuideRide()
        {
            GuideRideToRoutes = new HashSet<GuideRideToRoute>();
            GuideTickets = new HashSet<GuideTicket>();
        }
        public int Id { get; set; }
        public int GuideId { get; set; }
        public int TouristId { get; set; }

        public virtual Guide Guide { get; set; }
        public virtual Tourist Tourist { get; set; }
        public virtual ICollection<GuideRideToRoute> GuideRideToRoutes { get; set; }
        public virtual ICollection<GuideTicket> GuideTickets { get; set; }
    }

    public class GuideRideToRoute
    {
        public int Id { get; set; }
        public int GuideRideId { get; set; }
        public int RouteId { get; set; }
        public int FromToDateId { get; set; }

        public virtual GuideRide GuideRide { get; set; }
        public virtual Route Route { get; set; }
        public virtual FromToDate FromToDate { get; set; }
    }

    public class GuideTicket
    {
        public int Id { get; set; }
        public int GuideRideId { get; set; }
        public float TotalPrice { get; set; }
        public virtual GuideRide GuideRide { get; set; }
    }
}
