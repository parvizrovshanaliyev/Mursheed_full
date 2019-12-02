using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Mursheed.WebCoreMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult DriverRegister()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}