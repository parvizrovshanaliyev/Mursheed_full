using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Mursheed.WebCoreMVC_3_1.Areas.Dashboard.ViewComponents
{
    public class LeftSideNavViewComponent : ViewComponent
    {

        public Task<IViewComponentResult> InvokeAsync()
        {


            return Task.FromResult<IViewComponentResult>(View());
        }
    }
}
