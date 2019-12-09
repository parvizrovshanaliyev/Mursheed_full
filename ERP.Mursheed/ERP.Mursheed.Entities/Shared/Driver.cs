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
            
        }
        public int Id { get; set; }
        public string CustomId { get; set; }
        public int GovernmentalId { get; set; }
        public string DriverLicenseId { get; set; }
        public int CountryId { get; set; }
        public int CarId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Fullname => $"{Firstname} {Lastname}";
        public string PhotoName { get; set; }
        public string PhotoPath { get; set; }
        public bool Status { get; set; }

        public Country Country { get; set; }
        public Car Car { get; set; }

    }












    //[Table("TransporterRating")]
    //public class TransporterRating
    //{
    //    [Key] public int Id { get; set; }

    //    [Required]
    //    public int TouristId { get; set; }

    //    [Required]
    //    public int TransporterId { get; set; }

    //    [ForeignKey("TouristId")]
    //    public Tourist Tourist { get; set; }

    //    [ForeignKey("TransporterId")]
    //    public Driver Transporter { get; set; }

    //}

    

    


    


    //[Table("DateFromTo")]
    //public class DateFromTo
    //{
    //    public DateFromTo()
    //    {
    //        RideToRoutes = new HashSet<RideToRoute>();
    //    }
    //    [Key] public int Id { get; set; }

    //    [Required]
    //    public DateTime StartDate { get; set; }
    //    [Required]
    //    public DateTime EndDate { get; set; }

    //    public virtual ICollection<RideToRoute> RideToRoutes { get; set; }

    //}



    //[Table("Route")]
    //public class Route
    //{
    //    public Route()
    //    {
    //        RideToRoutes = new HashSet<RideToRoute>();
    //        TransporterRoutes = new HashSet<TransporterRoute>();
    //    }
    //    [Key] public int Id { get; set; }

    //    [Required]
    //    public int FromCityId { get; set; }

    //    [Required]
    //    public int ToCityId { get; set; }

    //    [Required]
    //    public float Price { get; set; }

    //    public string Info { get; set; }

    //    [ForeignKey("FromCityId")]
    //    public City FromCity { get; set; }

    //    [ForeignKey("ToCityId")]
    //    public City ToCity { get; set; }

    //    public virtual ICollection<RideToRoute> RideToRoutes { get; set; }
    //    public virtual ICollection<TransporterRoute> TransporterRoutes { get; set; }

    //}


    //[Table("Ride")]
    //public class Ride
    //{
    //    public Ride()
    //    {
    //        RideToRoutes = new HashSet<RideToRoute>();
    //        Tickets = new HashSet<Ticket>();
    //    }
    //    [Key] public int Id { get; set; }

    //    [Required]
    //    public int TouristId { get; set; }

    //    [Required]
    //    public int TransporterId { get; set; }

    //    [ForeignKey("TouristId")]
    //    public Tourist Tourist { get; set; }

    //    [ForeignKey("TransporterId")]
    //    public Driver Transporter { get; set; }

    //    public virtual ICollection<RideToRoute> RideToRoutes { get; set; }
    //    public virtual ICollection<Ticket> Tickets { get; set; }
    //}

    //[Table("RideToRoute")]
    //public class RideToRoute
    //{
    //    [Key] public int Id { get; set; }

    //    // [Required] 
    //    public int RideId { get; set; }

    //    //[Required] 
    //    public int RouteId { get; set; }

    //    //[Required] 
    //    public int DateFromToId { get; set; }

    //    //[ForeignKey("RideId")] 
    //    public Ride Ride { get; set; }

    //    //[ForeignKey("RouteId")] 
    //    public Route Route { get; set; }

    //    public DateFromTo DateFromTo { get; set; }
    //}

    //[Table("TransporterRoute")]
    //public class TransporterRoute
    //{
    //    [Key] public int Id { get; set; }

    //    [Required]
    //    public int TransporterId { get; set; }

    //    [Required]
    //    public int RouteId { get; set; }


    //    [ForeignKey("TransporterId")]
    //    public Driver Transporter { get; set; }

    //    [ForeignKey("RouteId")]
    //    public Route Route { get; set; }
    //}

    //[Table("Ticket")]
    //public class Ticket
    //{
    //    [Key] public int Id { get; set; }

    //    [Required]
    //    public int RideId { get; set; }

    //    [Required]
    //    public float TotalPrice { get; set; }

    //    [ForeignKey("RideId")]
    //    public virtual Ride Ride { get; set; }
    //}


}
