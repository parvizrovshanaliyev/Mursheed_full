namespace ERP.Mursheed.Entities.Shared
{
    public class Route
    {
        public Route()
        {
        }
        public int Id { get; set; }
        public int FromCityId { get; set; }
        public int ToCityId { get; set; } 
        public float Price { get; set; }
        public string Info { get; set; }

        public City FromCity { get; set; }
        public City ToCity { get; set; }
    }


    
    public class DriverRoute
    {
        public int Id { get; set; }
        public int TransporterId { get; set; }
        public int RouteId { get; set; }

        public Driver Transporter { get; set; }
        public Route Route { get; set; }
    }
}