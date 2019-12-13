using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
//using ERP.Mursheed.Entities.Shared;
//using ERP.Mursheed.Repositories.Interfaces;
using ERP.Mursheed.Utility;
using ERP.Mursheed.WebCoreMVC_3_1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Mursheed.WebCoreMVC_3_1.Facades
{
    public interface ITicketFacade
    {
        //TicketViewModel CreateTicket(TicketViewModel model);
        //TicketViewModel AddAsync(TicketViewModel model);
    }

    public class TicketFacade : ITicketFacade
    {
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;

        //public TicketFacade(IUnitOfWork unitOfWork, IMapper mapper)
        //{
        //    _unitOfWork = unitOfWork;
        //    _mapper = mapper;
        //}

        

        //public  TicketViewModel AddAsync(TicketViewModel model)
        //{
        //    // start date endDate
        //    // var dateFromTo = _mapper.Map<DateFromTo>(model.DateFromTo);
        //    var dateFromTo = new DateFromTo
        //    {
        //        StartDate = model.DateFromTo.StartDate,
        //        EndDate = model.DateFromTo.EndDate
        //    };
        //    _unitOfWork.Repository<DateFromTo>().AddUnCommitted(dateFromTo);

        //    var ride = new Ride
        //    {
        //        TouristId = 1,
        //        TransporterId = model.DriverId
        //    };
        //    // create ride
        //    _unitOfWork.Repository<Ride>().AddUnCommitted(ride);
            
        //    // find all routes
        //    if (model.RouteIds.Count == 0) return null;

        //    var routes = _unitOfWork.Repository<Route>().FindAll(x => model.RouteIds.Contains(x.Id));

        //    if (routes.Count == 0) return null;

        //    float totalPrice = 0;
        //    var rideToRoutes = new List<RideToRoute>();
        //    foreach (var route in routes)
        //    {
        //        var rideToRoute = new RideToRoute
        //        {
        //            RouteId = route.Id,
        //            RideId = ride.Id,
        //            DateFromToId = dateFromTo.Id
        //        };
        //        totalPrice += route.Price;
        //        rideToRoutes.Add(rideToRoute);
        //    }
        //    _unitOfWork.Repository<RideToRoute>().AddRangeUnCommitted(rideToRoutes);

        //    // final 
        //    var ticket = new Ticket
        //    {
        //        RideId = ride.Id,
        //        TotalPrice = totalPrice
        //    };

        //    _unitOfWork.Repository<Ticket>().AddUnCommitted(ticket);

        //    //var result = await _unitOfWork.Commit();
        //    var t = new TicketViewModel();
        //    return t;


        //}
    }
}
