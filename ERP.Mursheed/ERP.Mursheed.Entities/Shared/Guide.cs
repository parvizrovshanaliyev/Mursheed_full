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
        }
        public int Id { get; set; }
        public int GovernmentalId { get; set; }
        public int CountryId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Fullname => $"{Firstname} {Lastname}";
        public string PhotoName { get; set; }
        public string PhotoPath { get; set; }
        public bool Status { get; set; }

        public Country Country { get; set; }
        public virtual ICollection<GuideLanguage> GuideLanguages { get; set; }
    }


    
   
}
