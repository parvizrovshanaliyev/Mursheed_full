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

        public async Task<IActionResult> Index()
        {

            var country = new Country
            {
                Name = "Azerbaijan",
                NiceName = "AZERBAIJAN"
            };

            var insertCountryResult = _unitOfWork.Repository<Country>().AddUnCommitted(country);
            if (insertCountryResult.IsSuccess)
            {
                var city = new City
                {
                    CountryId = country.Id,
                    Name = "Ganja",
                    NiceName = "GANJA"
                };
                var insertCityResult = _unitOfWork.Repository<City>().AddUnCommitted(city);

                if (insertCityResult.IsSuccess)
                {
                    var commit =await _unitOfWork.Commit();

                    if (commit.IsSuccess)
                    {
                        return Content("ok");
                    }
                    return Content("olmadi yar");

                }

            }
            return Content("olmadi yar");
        }
    }
}