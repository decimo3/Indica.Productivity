using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Domain.Entities;

namespace Indica.System.Application.Mappers
{
    public class PaymentAutoMapper : Profile
    {
        public PaymentAutoMapper()
        {
            CreateMap<Payment, PaymentDTO>().ReverseMap();
        }
    }
}