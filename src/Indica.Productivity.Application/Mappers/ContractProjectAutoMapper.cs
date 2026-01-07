using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Application.Mappers
{
    public class ContractProjectAutoMapper : Profile
    {
        public ContractProjectAutoMapper()
        {
            CreateMap<ContractProject, ContractProjectDTO>()
                .ForMember(dest => dest.Contract, opt => opt.MapFrom(src => src.Contract.ContractNumber))
                .ForMember(dest => dest.Additive, opt => opt.MapFrom(src => src.Contract.AdditiveNumber))
                .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.Project.ProjectName))
                .ForMember(dest => dest.Derivation, opt => opt.MapFrom(src => src.Derivation.DerivationName))
                .ForMember(dest => dest.Regional, opt => opt.MapFrom(src => src.Regional.RegionName));
        }
    }
}
