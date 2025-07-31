using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Domain.Entities;

namespace Indica.System.Application.Mappers
{
    public class PaymentMasterAutoMapper : Profile
    {
        public PaymentMasterAutoMapper()
        {
            CreateMap<PaymentMaster, PaymentMasterDTO>().ReverseMap();
        }
    }
}