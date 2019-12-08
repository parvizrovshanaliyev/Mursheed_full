using Microsoft.AspNetCore.Mvc;

namespace ERP.Mursheed.WebCoreMVC_3_1.Areas.Dashboard.Controllers
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