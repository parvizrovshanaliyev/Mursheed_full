using AutoMapper;
using Entities.Shared;
//using ERP.Mursheed.Entities.Shared;
using ERP.Mursheed.WebCoreMVC_3_1.Controllers;
using ERP.Mursheed.WebCoreMVC_3_1.ViewModels;

namespace ERP.Mursheed.WebCoreMVC_3_1.Helper
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            //todo
            CreateMap<Country, TestController.CountryViewModel>().ReverseMap();
            CreateMap<City, TestController.CityViewModel>().ReverseMap();
            //CreateMap<DateFromTo, DateFromToViewModel>().ReverseMap();
        }
    }
}
