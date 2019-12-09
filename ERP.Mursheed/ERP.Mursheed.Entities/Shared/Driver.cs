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
            //TransporterRatings = new HashSet<TransporterRating>();
            //Rides = new HashSet<Ride>();
            //TransporterRoutes = new HashSet<TransporterRoute>();
        }
        public int Id { get; set; }

        public string CustomId { get; set; }

        //[DataType(DataType.PostalCode)]
        public int GovernmentalId { get; set; }

        //[Required]
        public string DriverLicenseId { get; set; }

        public int CountryId { get; set; }
        
        public int CarId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Fullname
        {
            get { return $"{Firstname} {Lastname}"; }
        }

        public string PersonalPhoto { get; set; }

        public bool Status { get; set; }

        //public Country Country { get; set; }

        //public Car Car { get; set; }

    }


    //[Table("Tourist")]
    //public class Tourist
    //{
    //    public Tourist()
    //    {
    //        TransporterRatings = new HashSet<TransporterRating>();
    //        Rides = new HashSet<Ride>();
    //    }

    //    [Key] public int Id { get; set; }

    //    [Required]
    //    public int CountryId { get; set; }

    //    [Required]
    //    [StringLength(50), MinLength(3)]
    //    public string Firstname { get; set; }

    //    [Required]
    //    [StringLength(50), MinLength(3)]
    //    public string Lastname { get; set; }


    //    [EmailAddress]
    //    public string Email { get; set; }

    //    public string AdditonalInfo { get; set; }

    //    public string Fullname
    //    {
    //        get { return $"{Firstname} {Lastname}"; }
    //    }
    //    public bool Status { get; set; }

    //    [ForeignKey("CountryId")]
    //    public virtual Country Country { get; set; }

    //    public virtual ICollection<TransporterRating> TransporterRatings { get; set; }
    //    public virtual ICollection<Ride> Rides { get; set; }

    //}

   
    //[Table("DriverLanguage")]
    //public class DriverLanguage
    //{
    //    [Key] public int Id { get; set; }

    //    [Required]
    //    public int DriverId { get; set; }

    //    [Required]
    //    public int LanguageId { get; set; }

    //    [ForeignKey("DriverId")]
    //    public Driver Driver { get; set; }

    //    [ForeignKey("LanguageId")]
    //    public Language Language { get; set; }
    //}


   


    //[Table("Language")]
    //public class Language
    //{
    //    public Language()
    //    {
    //        DriverLanguages = new HashSet<DriverLanguage>();
    //    }
    //    [Key] public int Id { get; set; }

    //    [Required] public string Name { get; set; }

    //    public virtual ICollection<DriverLanguage> DriverLanguages { get; set; }

    //}
   

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

    //[Table("Car")]
    //public class Car
    //{
    //    public Car()
    //    {
    //        Transporters = new HashSet<Driver>();
    //    }
    //    [Key] public int Id { get; set; }

    //    [Required]
    //    public int ModelId { get; set; }

    //    [ForeignKey("ModelId")]
    //    public Model Model { get; set; }

    //    public virtual ICollection<Driver> Transporters { get; set; }
    //}

    //[Table("Model")]
    //public class Model
    //{
    //    public Model()
    //    {
    //        Cars = new HashSet<Car>();
    //    }
    //    [Key] public int Id { get; set; }

    //    [Required]
    //    public int BrandId { get; set; }

    //    [Required]
    //    public string Name { get; set; }

    //    [ForeignKey("BrandId")]
    //    public Brand Brand { get; set; }

    //    public virtual ICollection<Car> Cars { get; set; }
    //}

    //[Table("Brand")]
    //public class Brand
    //{
    //    public Brand()
    //    {
    //        Models = new HashSet<Model>();
    //    }
    //    [Key] public int Id { get; set; }

    //    [Required]
    //    public string Name { get; set; }

    //    public virtual ICollection<Model> Models { get; set; }
    //}

    //[Table("Country")]
    //public class Country
    //{
    //    public Country()
    //    {
    //        Cities = new HashSet<City>();
    //        Transporters = new HashSet<Driver>();
    //        Tourists = new HashSet<Tourist>();
    //    }
    //    public int Id { get; set; }
    //    public string ISO { get; set; }
    //    public string Name { get; set; }
    //    public string NiceName { get; set; }
    //    public string ISO3 { get; set; }
    //    public string NumCode { get; set; }
    //    public string Phonecode { get; set; }

    //    public virtual ICollection<City> Cities { get; set; }
    //    public virtual ICollection<Driver> Transporters { get; set; }
    //    public virtual ICollection<Tourist> Tourists { get; set; }

    //}


    //[Table("City")]
    //public class City
    //{
    //    public City()
    //    {
    //        FromRoutes = new HashSet<Route>();
    //        ToRoutes = new HashSet<Route>();
    //    }
    //    [Key] public int Id { get; set; }

    //    [Required]
    //    public int CountryId { get; set; }

    //    [Required]
    //    public string Name { get; set; }
    //    //public string NiceName { get; set; }

    //    [ForeignKey("CountryId")]
    //    public Country Country { get; set; }

    //    public virtual ICollection<Route> FromRoutes { get; set; }
    //    public virtual ICollection<Route> ToRoutes { get; set; }
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



    //[Table("RoutePlace")]
    //public class RoutePlace
    //{
    //    public RoutePlace()
    //    {
    //        FromRoutes = new HashSet<Route>();
    //        ToRoutes = new HashSet<Route>();
    //    }
    //    [Key] public int Id { get; set; }

    //    public string Name { get; set; }

    //    public virtual ICollection<Route> FromRoutes { get; set; }
    //    public virtual ICollection<Route> ToRoutes { get; set; }
    //}

}
