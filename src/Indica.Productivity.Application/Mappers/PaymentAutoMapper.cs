using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Application.Mappers
{
    public class PaymentAutoMapper : Profile
    {
        public PaymentAutoMapper()
        {
            CreateMap<Payment, PaymentDTO>().ReverseMap();
        }
    }
}