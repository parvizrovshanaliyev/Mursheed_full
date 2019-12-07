using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Mursheed.Entities.Shared;
using ERP.Mursheed.Repositories.Interfaces;
using ERP.Mursheed.WebCoreMVC_3_1.ViewModels;

namespace ERP.Mursheed.WebCoreMVC_3_1.Facades
{
    public interface IDriverPriceFacade
    {
        DriverPriceViewModel GetTransporter(int id);

        //IQueryable<>
    }

    public class DriverPriceFacade : IDriverPriceFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DriverPriceFacade(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public DriverPriceViewModel GetTransporter(int id)
        {
            var driverModel = (from driver in _unitOfWork.Repository<Transporter>().Query()
                               join car in _unitOfWork.Repository<Car>().Query()
                                   on driver.CarId equals car.Id
                               join model in _unitOfWork.Repository<Model>().Query()
                                   on car.ModelId equals model.Id
                               join brand in _unitOfWork.Repository<Brand>().Query()
                                   on model.BrandId equals brand.Id
                               where driver.Id == id
                               select new DriverPriceViewModel
                               {
                                   Id = driver.Id,
                                   Fullname = driver.Fullname,
                                   CarName = brand.Name +' '+ model.Name,
                                   TotalRide = (from x in _unitOfWork.Repository<Ride>().Query()
                                                where x.Id == id
                                                select x).Count()
                               }).SingleOrDefault();
            return driverModel;
        }
    }
}
