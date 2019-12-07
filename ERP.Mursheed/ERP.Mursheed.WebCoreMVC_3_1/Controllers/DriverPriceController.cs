using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Mursheed.WebCoreMVC_3_1.Controllers
{
    public class DriverPriceController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}