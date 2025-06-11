using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Domain.Entities;

namespace Indica.System.Application.Mappers
{
    public class PaymentAutoMappers : Profile
    {
        public PaymentAutoMappers()
        {
            CreateMap<Payment, PaymentDTO>().ReverseMap();
        }
    }
}