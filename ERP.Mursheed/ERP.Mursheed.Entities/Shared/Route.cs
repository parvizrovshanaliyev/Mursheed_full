using System.Collections.Generic;

namespace ERP.Mursheed.Entities.Shared
{
    public class Route
    {
        public Route()
        {
            DriverRoutes = new HashSet<DriverRoute>();
            GuideRoutes = new HashSet<GuideRoute>();
            //
            GuideRideToRoutes = new HashSet<GuideRideToRoute>();
            DriverRideToRoutes = new HashSet<DriverRideToRoute>();
        }
        public int Id { get; set; }
        public int FromCityId { get; set; }
        public int ToCityId { get; set; } 
        public float Price { get; set; }
        public string Info { get; set; }

        public City FromCity { get; set; }
        public City ToCity { get; set; }
        public virtual ICollection<DriverRoute> DriverRoutes { get; set; }
        public virtual ICollection<GuideRoute> GuideRoutes { get; set; }
        //
        public virtual ICollection<GuideRideToRoute> GuideRideToRoutes { get; set; }
        public virtual ICollection<DriverRideToRoute> DriverRideToRoutes { get; set; }
    }


    
    public class DriverRoute
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int RouteId { get; set; }

        public Driver Driver { get; set; }
        public Route Route { get; set; }
    }

    public class GuideRoute
    {
        public int Id { get; set; }
        public int GuideId { get; set; }
        public int RouteId { get; set; }

        public Guide Guide { get; set; }
        public Route Route { get; set; }
    }
}