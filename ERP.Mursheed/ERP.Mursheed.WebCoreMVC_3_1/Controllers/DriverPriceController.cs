using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

using ERP.Mursheed.Utility;
using ERP.Mursheed.WebCoreMVC_3_1.Facades;
using ERP.Mursheed.WebCoreMVC_3_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ERP.Mursheed.WebCoreMVC_3_1.Controllers
{
    public class DriverPriceController : Controller
    {
        //private readonly IConfiguration _configuration;
        //private readonly IMapper _mapper;
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly IDriverPriceFacade _driverPriceFacade;
        //private readonly ITicketFacade _ticketFacade;

        
        //public DriverPriceController(IConfiguration configuration, 
        //    IMapper mapper, 
        //    IUnitOfWork unitOfWork, 
        //    IDriverPriceFacade driverPriceFacade, ITicketFacade ticketFacade)
        //{
        //    _configuration = configuration;
        //    _mapper = mapper;
        //    _unitOfWork = unitOfWork;
        //    _driverPriceFacade = driverPriceFacade;
        //    _ticketFacade = ticketFacade;
        //}

        // [Route("DriverPrice/{id}")]
        //public IActionResult Index(int? id)
        //{
        //    if (id == null) return NotFound();
        //    var model= _driverPriceFacade.GetTransporter((int) id);
        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<JsonResult> Ticket(TicketViewModel model)
        //{
        //    //if (!ModelState.IsValid) return new JsonResult(BadRequest());

        //    //var dateFromTo = new DateFromTo
        //    //{
        //    //    StartDate = model.DateFromTo.StartDate,
        //    //    EndDate = model.DateFromTo.EndDate
        //    //};
        //    //var dateFromToResult =await  _unitOfWork.Repository<DateFromTo>().AddAsync(dateFromTo);

        //    //if (!dateFromToResult.IsSuccess) return new JsonResult(BadRequest());
        //    //var ride = new Ride
        //    //{
        //    //    TouristId = 1,
        //    //    TransporterId = model.DriverId
        //    //};
        //    //// create ride
        //    //var insertedRideResult= await _unitOfWork.Repository<Ride>().AddAsync(ride);

        //    //if (!insertedRideResult.IsSuccess) return new JsonResult(BadRequest());
        //    //// find all routes
        //    //if (model.RouteIds.Count == 0) return null;

        //    //var routes =await _unitOfWork.Repository<Route>().FindAllAsync(x => model.RouteIds.Contains(x.Id));

        //    //if (routes.Count == 0) return null;

        //    //float totalPrice = 0;
        //    //var rideToRoutes = new List<RideToRoute>();
        //    //foreach (var route in routes)
        //    //{
        //    //    var rideToRoute = new RideToRoute
        //    //    {
        //    //        RouteId = route.Id,
        //    //        RideId = ride.Id,
        //    //        DateFromToId = dateFromTo.Id
        //    //    };
        //    //    totalPrice += route.Price;
        //    //    rideToRoutes.Add(rideToRoute);
        //    //}
        //    //var insertedRideToRoutesResult = await _unitOfWork.Repository<RideToRoute>().AddRangeAsync(rideToRoutes);
        //    //if (!insertedRideToRoutesResult.IsSuccess) return new JsonResult(BadRequest());
        //    //// final 
        //    //var ticket = new Ticket
        //    //{
        //    //    RideId = ride.Id,
        //    //    TotalPrice = totalPrice
        //    //};

        //    //var insertedTicketResult=await _unitOfWork.Repository<Ticket>().AddAsync(ticket);

        //    //if (insertedRideResult.IsSuccess)
        //    //{
        //    //    return  Json(new{rideId=ride.Id, totalPrice=totalPrice});
        //    //}

        //    //var allCommitResult =_unitOfWork.Commit();
        //    //if (allCommitResult.IsCompletedSuccessfully)
        //    //{
                
        //    //}

        //    return new JsonResult(BadRequest());
        //}
    }
}