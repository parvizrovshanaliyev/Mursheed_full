using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Mursheed.WebCoreMVC_3_1.ViewModels
{
    public class DriverRegisterViewModel
    {
        /// <summary>
        /// Personal info
        /// </summary>
        /// 
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public IEnumerable<int> LanguageIds { get; set; }

        public IFormFile Photo { get; set; }
        /// <summary>
        /// Car Details
        /// </summary>
        
        [Required]
        public int BrandId { get; set; }

        [Required]
        public int ModelId { get; set; }

        public IEnumerable<IFormFile> CarPhoto { get; set; }

    }

    public class CarPhotoViewModel
    {

        public int Id { get; set; }
        public int CarId { get; set; }
        public string PhotoName { get; set; }
        public string PhotoPath { get; set; }
    }

    public class LanguageViewModel
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}

