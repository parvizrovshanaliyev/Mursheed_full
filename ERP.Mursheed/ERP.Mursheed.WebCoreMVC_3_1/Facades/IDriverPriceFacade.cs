using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
//using ERP.Mursheed.Entities.Shared;
//using ERP.Mursheed.Repositories.Interfaces;
using ERP.Mursheed.WebCoreMVC_3_1.ViewModels;

namespace ERP.Mursheed.WebCoreMVC_3_1.Facades
{
    public interface IDriverPriceFacade
    {
        //DriverPriceViewModel GetTransporter(int id);

        //IQueryable<Select2ViewModel> GetFromRoute(FromToRouteViewModel model);
        //IQueryable<Select2ViewModel> GetToRouteForFromRoute(FromToRouteViewModel model);
        //Select2ViewModel GetToCostForRoute(FromToRouteViewModel model);
        //IQueryable<>
    }

    public class DriverPriceFacade : IDriverPriceFacade
    {
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;

        //public DriverPriceFacade(IUnitOfWork unitOfWork, IMapper mapper)
        //{
        //    _unitOfWork = unitOfWork;
        //    _mapper = mapper;
        //}

        //public DriverPriceViewModel GetTransporter(int id)
        //{
        //    var driverModel = (from driver in _unitOfWork.Repository<Driver>().Query()
        //                       join car in _unitOfWork.Repository<Car>().Query()
        //                           on driver.CarId equals car.Id
        //                       join model in _unitOfWork.Repository<Model>().Query()
        //                           on car.ModelId equals model.Id
        //                       join brand in _unitOfWork.Repository<Brand>().Query()
        //                           on model.BrandId equals brand.Id
        //                       where driver.Id == id
        //                       select new DriverPriceViewModel
        //                       {
        //                           Id = driver.Id,
        //                           Fullname = driver.Fullname,
        //                           CarName = brand.Name +' '+ model.Name,
        //                           TotalRide = (from x in _unitOfWork.Repository<Ride>().Query()
        //                                        where x.Id == id
        //                                        select x).Count()
        //                       }).SingleOrDefault();
        //    return driverModel;
        //}

        //public IQueryable<Select2ViewModel> GetFromRoute(FromToRouteViewModel model)
        //{
        //    var fromRoutes = (from tRoute in _unitOfWork.Repository<TransporterRoute>().Query()
        //        join driver in _unitOfWork.Repository<Driver>().Query()
        //            on tRoute.TransporterId equals driver.Id
        //        join route in _unitOfWork.Repository<Route>().Query()
        //            on tRoute.RouteId equals route.Id
        //        join fromCity in _unitOfWork.Repository<City>().Query()
        //            on route.FromCityId equals fromCity.Id
        //        where driver.Id == model.DriverId
        //        select new Select2ViewModel
        //        {
        //            id = fromCity.Id,
        //            text = fromCity.Name
        //        }).Distinct();
        //    return fromRoutes;
        //}

        //public IQueryable<Select2ViewModel> GetToRouteForFromRoute(FromToRouteViewModel model)
        //{
        //    var toRoutes = (from tRoute in _unitOfWork.Repository<TransporterRoute>().Query()
        //        join driver in _unitOfWork.Repository<Driver>().Query()
        //            on tRoute.TransporterId equals driver.Id
        //        join route in _unitOfWork.Repository<Route>().Query()
        //            on tRoute.RouteId equals route.Id
        //        join fromCity in _unitOfWork.Repository<City>().Query()
        //            on route.FromCityId equals fromCity.Id
        //        join toCity in _unitOfWork.Repository<City>().Query()
        //            on route.ToCityId equals toCity.Id
        //        where driver.Id == model.DriverId && fromCity.Id == model.FromRouteId
        //        select new Select2ViewModel
        //        {
        //            id = toCity.Id,
        //            text = toCity.Name
        //        });
        //    return toRoutes;
        //}

        //public Select2ViewModel GetToCostForRoute(FromToRouteViewModel model)
        //{
        //    var fromToRoute = (from tRoute in _unitOfWork.Repository<TransporterRoute>().Query()
        //        join driver in _unitOfWork.Repository<Driver>().Query()
        //            on tRoute.TransporterId equals driver.Id
        //        join route in _unitOfWork.Repository<Route>().Query()
        //            on tRoute.RouteId equals route.Id
        //        join fromCity in _unitOfWork.Repository<City>().Query()
        //            on route.FromCityId equals fromCity.Id
        //        join toCity in _unitOfWork.Repository<City>().Query()
        //            on route.ToCityId equals toCity.Id
        //        where driver.Id == model.DriverId && fromCity.Id == model.FromRouteId && toCity.Id == model.ToRouteId
        //        select new Select2ViewModel
        //        {
        //            id = route.Id,
        //            cost = route.Price,
        //            text = route.Info
        //        }).SingleOrDefault();
        //    return fromToRoute;
        //}
    }
}
