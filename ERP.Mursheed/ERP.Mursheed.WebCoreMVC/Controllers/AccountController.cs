using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ERP.Mursheed.Entities.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Mursheed.WebCoreMVC.Controllers
{
    
    public class AccountController : Controller
    {
        #region Login
        [HttpGet]
        [Route("Account/{login}")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Account/{login}")]
        public IActionResult Login(Person person) // todo
        {
            return View();
        }
        #endregion

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        #region Register Driver
        [HttpGet]
        [ActionName("driverRegister")]
        public IActionResult DriverRegister()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("driverRegister")]
        public IActionResult DriverRegister(Person person) // todo viewmodel
        {
            return View();
        }
        #endregion

        #region Register Guide
        [HttpGet]
        [ActionName("guideRegister")]
        public IActionResult GuideRegister()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("guideRegister")]
        public IActionResult GuideRegister(Person person) // todo viewmodel
        {
            return View();
        }
        #endregion

        #region Register Tourist = Customer
        [HttpGet]
        public IActionResult TouristRegister()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TouristRegister(Person person) // todo viewmodel
        {
            return View();
        }
        #endregion

        #region TranspostationAgencyRegister
        [HttpGet]
        public IActionResult AgencyRegister()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgencyRegister(Person person) // todo viewmodel
        {
            return View();
        }
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            return View();
        }
    }
}