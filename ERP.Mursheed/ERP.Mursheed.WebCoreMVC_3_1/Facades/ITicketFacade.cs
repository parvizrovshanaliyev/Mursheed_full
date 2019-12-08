using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ERP.Mursheed.Repositories.Interfaces;
using ERP.Mursheed.WebCoreMVC_3_1.ViewModels;

namespace ERP.Mursheed.WebCoreMVC_3_1.Facades
{
    public interface ITicketFacade
    {
        TicketViewModel CreateTicket(TicketViewModel model);
    }

    public class TicketFacade : ITicketFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TicketFacade(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public TicketViewModel CreateTicket(TicketViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
