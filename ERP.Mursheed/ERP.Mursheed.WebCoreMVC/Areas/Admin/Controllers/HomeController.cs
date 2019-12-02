using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Mursheed.WebCoreMVC.Areas.Admin.Controllers
{
    [Area("Dashboard")]
    [Route("Dashboard/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}