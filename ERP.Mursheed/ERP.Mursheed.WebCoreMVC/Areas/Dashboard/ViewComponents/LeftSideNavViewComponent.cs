using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Mursheed.WebCComporeMVC.Areas.Dashboard.ViewComponents
{
    public class LeftSideNavViewComponent : ViewComponent
    {

        public Task<IViewComponentResult> InvokeAsync()
        {


            return Task.FromResult<IViewComponentResult>(View());
        }
    }
}
