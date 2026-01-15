using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Application.Mappers
{
    public class PaymentAutoMapper : Profile
    {
        public PaymentAutoMapper()
        {
            CreateMap<Payment, PaymentDTO>()
                .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractProject.Contract.ContractNumber))
                .ForMember(dest => dest.AdditiveNumber, opt => opt.MapFrom(src => src.ContractProject.Contract.AdditiveNumber))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.ContractProject.Project.ProjectName))
                .ForMember(dest => dest.Derivation, opt => opt.MapFrom(src => src.ContractProject.Derivation.DerivationName))
                .ForMember(dest => dest.Master, opt => opt.MapFrom(src => src.Mestre))
                .ForMember(dest => dest.Valuation, opt => opt.MapFrom(src => src.Valuation));
        }
    }
}