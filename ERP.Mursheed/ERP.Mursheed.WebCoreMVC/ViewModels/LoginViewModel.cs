using ERP.Mursheed.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Mursheed.WebCoreMVC.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = ResultConst.RequiredProperty)]
        public string Username { get; set; }

        [Required(ErrorMessage = ResultConst.RequiredProperty)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
