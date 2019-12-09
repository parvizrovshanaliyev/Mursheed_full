using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Mursheed.Entities.Shared
{
    public class FromToDate
    {
        public FromToDate()
        {
            DriverRideToRoutes = new HashSet<DriverRideToRoute>();
            GuideRideToRoutes = new HashSet<GuideRideToRoute>();
        }
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<DriverRideToRoute> DriverRideToRoutes { get; set; }
        public virtual ICollection<GuideRideToRoute>  GuideRideToRoutes { get; set; }
    }
}
