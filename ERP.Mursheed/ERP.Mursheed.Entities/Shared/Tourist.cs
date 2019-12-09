using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Mursheed.Entities.Shared
{
    public class Tourist
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string AdditionalInfo { get; set; }

        public string Fullname
        {
            get { return $"{Firstname} {Lastname}"; }
        }
        public virtual Country Country { get; set; }
    }
}
