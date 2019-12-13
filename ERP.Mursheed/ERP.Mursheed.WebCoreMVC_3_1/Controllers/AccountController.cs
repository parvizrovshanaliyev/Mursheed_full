using Entities.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Mursheed.WebCoreMVC_3_1.Controllers
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
        [Route("{Register}")]
        public IActionResult Register()
        {
            return View();
        }


        #region Register Driver
        [HttpGet]
        [ActionName("driverRegister")]
        [Route("{Register}/Driver")]
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
        [Route("{Register}/Guide")]
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
        [Route("{Register}/Tourist")]
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
        [Route("{Register}/Agency")]
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