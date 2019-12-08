using AutoMapper;
using ERP.Mursheed.Entities.Shared;
using ERP.Mursheed.WebCoreMVC_3_1.ViewModels;

namespace ERP.Mursheed.WebCoreMVC_3_1.Helper
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            //todo
            CreateMap<Transporter, DriverPriceViewModel>();
            CreateMap<DateFromTo, DateFromToViewModel>().ReverseMap();
        }
    }
}
