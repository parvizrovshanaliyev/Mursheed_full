using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Mursheed.Entities.Shared;
using ERP.Mursheed.Repositories.Interfaces;
using ERP.Mursheed.WebCoreMVC_3_1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Mursheed.WebCoreMVC_3_1.Controllers
{
    public class Select2Controller : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public Select2Controller(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region From Route
        public JsonResult GetFromRoute(int id)
        {
            //List<Select2ViewModel> list = null;

            //if (!(string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search)))
            //{
            //    list = _unitOfWork.Repository<Personel>().Query().
            //        Where(x => x.Fullname.ToLower().StartsWith(search.ToLower()))
            //        .Select(x => new Select2ViewModel
            //        {
            //            text = x.Fullname,
            //            id = x.Id
            //        }).ToList();
            //}

            var fromRoutes = (from tRoute in _unitOfWork.Repository<TransporterRoute>().Query()
                              join driver in _unitOfWork.Repository<Transporter>().Query()
                                  on tRoute.TransporterId equals driver.Id
                              join route in _unitOfWork.Repository<Route>().Query()
                                  on tRoute.RouteId equals route.Id
                              join fromCity in _unitOfWork.Repository<City>().Query()
                                  on route.FromCityId equals fromCity.Id
                              where driver.Id == id
                              select new Select2ViewModel
                              {
                                  id = fromCity.Id,
                                  text = fromCity.Name
                              }).Distinct();

            return Json(new { items = fromRoutes });

        }
        #endregion
        #region From Route
        public JsonResult GetToRouteForFromRoute(int fromRouteId, int driverId)
        {
            var toRoutes = (from tRoute in _unitOfWork.Repository<TransporterRoute>().Query()
                            join driver in _unitOfWork.Repository<Transporter>().Query()
                                on tRoute.TransporterId equals driver.Id
                            join route in _unitOfWork.Repository<Route>().Query()
                                on tRoute.RouteId equals route.Id
                            join fromCity in _unitOfWork.Repository<City>().Query()
                                on route.FromCityId equals fromCity.Id
                            join toCity in _unitOfWork.Repository<City>().Query()
                                on route.ToCityId equals toCity.Id
                            where driver.Id == driverId && fromCity.Id == fromRouteId
                            select new Select2ViewModel
                            {
                                id = toCity.Id,
                                text = toCity.Name
                            });

            return Json(new { items = toRoutes });

        }
        #endregion
    }
}