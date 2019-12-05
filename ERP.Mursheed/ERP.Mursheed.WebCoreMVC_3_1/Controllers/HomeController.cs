using Microsoft.AspNetCore.Mvc;

namespace ERP.Mursheed.WebCoreMVC_3_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
