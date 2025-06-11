using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Domain.Entities;

namespace Indica.System.Application.Mappers
{
    public class FinishingPaymentAutoMapper : Profile
    {
        public FinishingPaymentAutoMapper()
        {
            CreateMap<FinishingPaymentDTO, FinishingPayment>().ReverseMap();
        }
    }
}
