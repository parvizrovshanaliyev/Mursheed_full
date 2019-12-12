using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Mursheed.Entities.Shared;
using ERP.Mursheed.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ERP.Mursheed.WebCoreMVC_3_1.Controllers
{
    public class TestController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        


        public TestController(IMapper mapper,
            IUnitOfWork unitOfWork,
            IConfiguration configuration
            )
        {
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public class CountryViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
           
        }
        public class CityViewModel
        {
            public int Id { get; set; }
            public int CountryId { get; set; }
            public string Name { get; set; }
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int id)
        {
            var country = new Country
            {
               
                Name = "Azerbaijan",
                NiceName = "AZERBAIJAN"
            };

            _unitOfWork.Repository<Country>().AddUnCommitted(country);
            var city = new City
            {

                CountryId = 1,
                Name = "Ganja",
                NiceName = "GANJA"
            };
            _unitOfWork.Repository<City>().AddUnCommitted(city);

            var commit = await _unitOfWork.Commit();

            if (commit.IsSuccess)
            {
                return Content("ok");
            }
            return Content("olmadi yar");
        }
    }
}