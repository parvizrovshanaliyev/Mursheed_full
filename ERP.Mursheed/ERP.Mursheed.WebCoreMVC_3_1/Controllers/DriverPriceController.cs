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
    [Route("DriverPrice")]
    public class DriverPriceController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDriverPriceFacade _driverPriceFacade;

        
        public DriverPriceController(IConfiguration configuration, IMapper mapper, IUnitOfWork unitOfWork, IDriverPriceFacade driverPriceFacade)
        {
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _driverPriceFacade = driverPriceFacade;
        }

        [Route("{id}")]
        public IActionResult Index(int? id)
        {
            if (id == null) return NotFound();
            var model= _driverPriceFacade.GetTransporter((int) id);
            return View(model);
        }
    }
}