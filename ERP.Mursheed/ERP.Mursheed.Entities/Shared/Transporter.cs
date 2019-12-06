using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP.Mursheed.Entities.Shared
{
    [Table("Transporter")]
    public class Transporter
    {
        public Transporter()
        {
            TransporterRatings = new HashSet<TransporterRating>();
            Rides = new HashSet<Ride>();
        }
        [Key] public int Id { get; set; }

        public int CarId { get; set; }

        [Required]
        [StringLength(50), MinLength(3)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50), MinLength(3)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(50), MinLength(3)]
        public string FatherName { get; set; }

        public string Fullname
        {
            get { return $"{Firstname} {Lastname} {FatherName}"; }
        }

        [ForeignKey("CarId")]
        public Car Car { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<TransporterRating> TransporterRatings { get; set; } 
        public virtual ICollection<Ride> Rides { get; set; } 
    }

    [Table("Tourist")]
    public class Tourist
    {
        public Tourist()
        {
            TransporterRatings = new HashSet<TransporterRating>();
            Rides = new HashSet<Ride>();
        }

        [Key] public int Id { get; set; }

        [Required]
        [StringLength(50), MinLength(3)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50), MinLength(3)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(50), MinLength(3)]
        public string FatherName { get; set; }

        public string Fullname
        {
            get { return $"{Firstname} {Lastname} {FatherName}"; }
        }
        public bool Status { get; set; }

        public virtual ICollection<TransporterRating> TransporterRatings { get; set; }
        public virtual ICollection<Ride> Rides { get; set; }

    }

    [Table("TransporterRating")]
    public class TransporterRating
    {
        [Key] public int Id { get; set; }

        [Required]
        public int TouristId { get; set; }

        [Required]
        public int TransporterId { get; set; }

        [ForeignKey("TouristId")]
        public Tourist Tourist { get; set; }

        [ForeignKey("TransporterId")]
        public Transporter Transporter { get; set; }

    }

    [Table("Car")]
    public class Car
    {
        public Car()
        {
            Transporters = new HashSet<Transporter>();
        }
        [Key] public int Id { get; set; }

        [Required]
        public int ModelId { get; set; }

        [ForeignKey("ModelId")]
        public Model Model { get; set; }

        public virtual ICollection<Transporter> Transporters { get; set; }
    }

    [Table("Model")]
    public class Model
    {
        [Key] public int Id { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
    }

    [Table("Brand")]
    public class Brand
    {
        public Brand()
        {
            Models = new HashSet<Model>();
        }
        [Key] public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }

    [Table("Country")]
    public class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }
        public int Id { get; set; }
        public string ISO { get; set; }
        public string Name { get; set; }
        public string NiceName { get; set; }
        public string ISO3 { get; set; }
        public string NumCode { get; set; }
        public string Phonecode { get; set; }

        public virtual ICollection<City> Cities { get; set; }

    }


    [Table("City")]
    public class City
    {
        [Key] public int Id { get; set; }

        [Required]
        public int BrandId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }


    [Table("DateFromTo")]
    public class DateFromTo
    {
        public DateFromTo()
        {
            RideToRoutes = new HashSet<RideToRoute>();
        }
        [Key] public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<RideToRoute> RideToRoutes { get; set; }

    }


    [Table("RoutePlace")]
    public class RoutePlace
    {
        public RoutePlace()
        {
            FromRoutes = new HashSet<Route>();
            ToRoutes = new HashSet<Route>();
        }
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Route> FromRoutes { get; set; }
        public virtual ICollection<Route> ToRoutes { get; set; }
    }

    [Table("Route")]
    public class Route
    {
        public Route()
        {
            RideToRoutes = new HashSet<RideToRoute>();
        }
        [Key] public int Id { get; set; }

        [Required]
        public int FromRoutePlaceId { get; set; }

        [Required]
        public int ToRoutePlaceId { get; set; }

        [Required]
        public float Price { get; set; }

        public string Info { get; set; }

        [ForeignKey("FromRoutePlaceId")]
        public RoutePlace FromRoutePlace { get; set; }

        [ForeignKey("ToRoutePlaceId")]
        public RoutePlace ToRoutePlace { get; set; }

        public virtual ICollection<RideToRoute> RideToRoutes { get; set; }

    }


    [Table("Ride")]
    public class Ride
    {
        public Ride()
        {
            RideToRoutes = new HashSet<RideToRoute>();
        }
        [Key] public int Id { get; set; }

        [Required]
        public int TouristId { get; set; }

        [Required]
        public int TransporterId { get; set; }

        [ForeignKey("TouristId")]
        public Tourist Tourist { get; set; }

        [ForeignKey("TransporterId")]
        public Transporter Transporter { get; set; }

        public virtual ICollection<RideToRoute> RideToRoutes { get; set; }
    }

    [Table("RideToRoute")]
    public class RideToRoute
    {
        public RideToRoute()
        {
            Tickets = new HashSet<Ticket>();
        }
        [Key] public int Id { get; set; }

        [Required]
        public int RideId { get; set; }

        [Required]
        public int RouteId { get; set; }
        
        [Required]
        public int DateFromToId { get; set; }

        [ForeignKey("RideId")]
        public Ride Ride { get; set; }

        [ForeignKey("RouteId")]
        public Route Route { get; set; }

        [ForeignKey("DateFromToId")]
        public DateFromTo DateFromTo { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }

    [Table("Ticket")]
    public class Ticket
    {
        [Key] public int Id { get; set; }

        [Required]
        public int RideToRouteId { get; set; }

        [Required]
        public float TotalPrice { get; set; }

        [ForeignKey("RideToRouteId")]
        public virtual RideToRoute RideToRoute { get; set; }
    }
}
