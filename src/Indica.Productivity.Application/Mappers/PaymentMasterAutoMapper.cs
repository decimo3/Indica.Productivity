using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Application.Mappers
{
    public class PaymentMasterAutoMapper : Profile
    {
        public PaymentMasterAutoMapper()
        {
            CreateMap<PaymentMaster, PaymentMasterDTO>().ReverseMap();
        }
    }
}