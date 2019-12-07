using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Mursheed.WebCoreMVC_3_1.ViewModels
{
    public class DriverPriceViewModel
    {
        public int Id { get; set; }

        public string Fullname { get; set; }

        public string CarName { get; set; }

        public bool Status { get; set; }

        public int TotalRide { get; set; }
    }
}
