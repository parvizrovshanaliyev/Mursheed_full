using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Mursheed.Entities.Shared
{
    /// <summary>
    /// 4 tip adam var Driver Guides Tourist Agency  bunlar ucun ortak olan ve olmayan xususiyyetlere uygun tablllar nece olmalidir sual 1
    /// Driversdeki total rides neye esasen hesablanacaq
    /// Driver ID neye esasen yazilacaq 
    /// </summary>
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

        [Required]
        public DateTimeOffset DateOfBirth { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

    }



    /// <summary>
    /// driverle car arasinda hemcinin brand ve model arasindaki elage araya pivot  pivotun adi 
    /// </summary>
    [Table("Car")]
    public class Car
    {
        [Key] public int Id { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public int ModelId { get; set; }
    }


    [Table("AvailableDate")]
    public class AvailableDate
    {
        [Key] public int Id { get; set; }

        [Required]
        public DateTimeOffset StarDate { get; set; }

        [Required]
        public DateTimeOffset EndDate { get; set; }

    }

    [Table("Package")]
    public class Package
    {
        [Key] public int Id { get; set; }

        [Required]
        [StringLength(50), MinLength(3)]
        public string Title { get; set; }

        [Required]
        [StringLength(50), MinLength(3)]
        public string Description { get; set; }

    }
}
