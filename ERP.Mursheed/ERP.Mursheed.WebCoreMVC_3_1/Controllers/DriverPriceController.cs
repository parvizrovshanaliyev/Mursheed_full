using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Mursheed.Entities.Shared;
using ERP.Mursheed.Repositories.Interfaces;
using ERP.Mursheed.Utility;
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
        private readonly ITicketFacade _ticketFacade;

        
        public DriverPriceController(IConfiguration configuration, 
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            IDriverPriceFacade driverPriceFacade, ITicketFacade ticketFacade)
        {
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _driverPriceFacade = driverPriceFacade;
            _ticketFacade = ticketFacade;
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


            //try
            //{
            //    var t = _ticketFacade.AddAsync(model);
            //    var commitResult = await _unitOfWork.Commit();
            //    if (commitResult.IsSuccess)
            //    {
            //        return Json(new { t });
            //    }
            //}
            //catch (Exception exception)
            //{
            //    return Json(new { exception });
            //}
            

            return new JsonResult(BadRequest());
        }
    }
}