using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Mursheed.Entities.Shared
{
    [Table("Country")]
    public class Country
    {
        public Country()
        {
            People = new HashSet<Person>();
        }
        public int Id { get; set; }
        public string ISO { get; set; }
        public string Name { get; set; }
        public string NiceName { get; set; }
        public string ISO3 { get; set; }
        public string NumCode { get; set; }
        public string Phonecode { get; set; }

        public virtual ICollection<Person> People { get; set; }

    }
}
