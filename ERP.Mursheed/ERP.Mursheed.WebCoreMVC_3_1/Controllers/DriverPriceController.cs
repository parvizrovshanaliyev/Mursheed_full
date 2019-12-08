using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Mursheed.Entities.Shared;
using ERP.Mursheed.Repositories.Interfaces;
using ERP.Mursheed.WebCoreMVC_3_1.Facades;
using ERP.Mursheed.WebCoreMVC_3_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ERP.Mursheed.WebCoreMVC_3_1.Controllers
{
    public class DriverPriceController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDriverPriceFacade _driverPriceFacade;

        
        public DriverPriceController(IConfiguration configuration, 
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            IDriverPriceFacade driverPriceFacade)
        {
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _driverPriceFacade = driverPriceFacade;
        }

        [Route("DriverPrice/{id}")]
        public IActionResult Index(int? id)
        {
            if (id == null) return NotFound();
            var model= _driverPriceFacade.GetTransporter((int) id);
            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> Ticket(TicketViewModel model)
        {
            if (!ModelState.IsValid) return new JsonResult(BadRequest());

            var ride = new Ride
            {
                TouristId = 1,
                TransporterId = model.DriverId
            };
            // create ride
            _unitOfWork.Repository<Ride>().AddUnCommitted(ride);
            // start date endDate
            var dateFromTo = _mapper.Map<DateFromTo>(model.DateFromTo);
            _unitOfWork.Repository<DateFromTo>().AddUnCommitted(dateFromTo);
            // find all routes
            if (model.RouteIds.Count <= 0) return new JsonResult(BadRequest());
            var routes = await _unitOfWork.Repository<Route>().FindAllAsync(x => model.RouteIds.Contains(x.Id));
            if (routes.Count <= 0) return new JsonResult(BadRequest());
            float totalPrice = 0;
            var rideToRoutes = new List<RideToRoute>();
            foreach (var route in routes)
            {
                var rideToRoute = new RideToRoute
                {
                    RouteId = route.Id,
                    RideId = ride.Id,
                    DateFromToId = dateFromTo.Id
                };
                totalPrice += route.Price;
                rideToRoutes.Add(rideToRoute);
            }

            _unitOfWork.Repository<RideToRoute>().AddRangeUnCommitted(rideToRoutes);

            // final 
            var ticket = new Ticket
            {
                RideId = ride.Id,
                TotalPrice = totalPrice
            };
            _unitOfWork.Repository<Ticket>().AddUnCommitted(ticket);
            var result = _unitOfWork.Commit();
            return result.IsCompletedSuccessfully ? Json(new {id = ticket.Id, totalPrice = ticket.TotalPrice}) : new JsonResult(BadRequest());
        }
    }
}