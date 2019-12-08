using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Mursheed.WebCoreMVC_3_1.ViewModels
{
    public class TicketViewModel
    {
        [Required]
        public List<int> RouteIds  { get; set; }

        [Required]
        public float  TotalPrice { get; set; }

        [Required]
        public int DriverId { get; set; }

        [Required]
        public DateFromTo DateFromTo { get; set; }

        // sistemde online olan tourist in user idsine gore tourist id goturulecek
        //[Required]
        //public int TouristId { get; set; }

    }

    public class DateFromTo
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
