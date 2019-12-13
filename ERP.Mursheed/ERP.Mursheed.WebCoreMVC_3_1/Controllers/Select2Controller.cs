using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ERP.Mursheed.WebCoreMVC_3_1.Facades;
using ERP.Mursheed.WebCoreMVC_3_1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Mursheed.WebCoreMVC_3_1.Controllers
{
    public class Select2Controller : Controller
    {
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly IDriverPriceFacade _driverPriceFacade;

        //public Select2Controller(IUnitOfWork unitOfWork,
        //                         IDriverPriceFacade driverPriceFacade)
        //{
        //    _unitOfWork = unitOfWork;
        //    _driverPriceFacade = driverPriceFacade;
        //}

        //#region GetFromRoute
        //[HttpPost]
        //public JsonResult GetFromRoute([Bind(include: "DriverId")]FromToRouteViewModel model)
        //{
        //    if (model.DriverId == 0) return new JsonResult(BadRequest());
        //    var fromRoutes = _driverPriceFacade.GetFromRoute(model);
        //    return Json(new { items = fromRoutes });

        //}
        //#endregion
        //#region GetToRouteForFromRoute
        //[HttpPost]
        //public JsonResult GetToRouteForFromRoute([Bind(include: "FromRouteId, DriverId")]FromToRouteViewModel model)
        //{
        //    if (model.DriverId == 0 && model.FromRouteId == 0) return new JsonResult(BadRequest());
        //    var toRoutes = _driverPriceFacade.GetToRouteForFromRoute(model);
        //    return Json(new { items = toRoutes });

        //}
        //#endregion
        //#region GetToCostForRoute
        //[HttpPost]
        //public JsonResult GetToCostForRoute([Bind(include: "FromRouteId, DriverId , ToRouteId")]FromToRouteViewModel model)
        //{
        //    if (model.DriverId == 0 && model.FromRouteId == 0 && model.ToRouteId == 0) return new JsonResult(BadRequest());
        //    var fromToRoute = _driverPriceFacade.GetToCostForRoute(model);
        //    return Json(new { cost = fromToRoute.cost, id = fromToRoute.id, info = fromToRoute.text });


        //}
        //#endregion
    }
}