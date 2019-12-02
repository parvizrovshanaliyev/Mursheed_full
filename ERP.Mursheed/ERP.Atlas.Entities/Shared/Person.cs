using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP.Atlas.Entities.Shared
{
    [Table("Person")]

    public class Person
    {
        public Person()
        {
            ApplicationUsers = new HashSet<ApplicationUser>();
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

        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
