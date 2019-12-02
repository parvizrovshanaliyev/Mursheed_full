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

        [HttpGet]
        [Route("{register}")]
        public IActionResult Register()
        {
            return View();
        }

        #region Register Driver
        [HttpGet]
        [Route("register/{driver}")]
        public IActionResult Driver()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("register/{guide}")]
        public IActionResult Driver(Person person) // todo viewmodel
        {
            return View();
        }
        #endregion

        #region Register Guide
        [HttpGet]
        [Route("register/{guide}")]
        public IActionResult Guide()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("register/{driver}")]
        public IActionResult Guide(Person person) // todo viewmodel
        {
            return View();
        }
        #endregion

        #region Register Tourist
        [HttpGet]
        [Route("register/{tourist}")]
        public IActionResult Tourist()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("register/{tourist}")]
        public IActionResult Tourist(Person person) // todo viewmodel
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