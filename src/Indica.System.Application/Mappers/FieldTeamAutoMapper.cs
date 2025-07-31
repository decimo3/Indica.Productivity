using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Domain.Entities;

namespace Indica.System.Application.Mappers
{
    public class FieldTeamAutoMapper : Profile
    {
        public FieldTeamAutoMapper()
        {
            CreateMap<FieldTeam, FieldTeamDTO>()
                .ForMember(dest => dest.WorkArea, opt => opt.MapFrom(src => src.Regional.RegionName))
                .ForMember(dest => dest.ActivityName, opt => opt.MapFrom(src => src.Activity.ActivityName))

                .ForMember(dest => dest.EmployerRegistry1, opt => opt.MapFrom((src, dest) =>
                    src.Couples.FirstOrDefault(f => f.Function.FunctionName == "executor1")?.Employer?.Id ?? 0))
                .ForMember(dest => dest.EmployerName1, opt => opt.MapFrom((src, dest) =>
                    src.Couples.FirstOrDefault(f => f.Function.FunctionName == "executor1")?.Employer?.FullName ?? string.Empty))

                .ForMember(dest => dest.EmployerRegistry2, opt => opt.MapFrom((src, dest) =>
                    src.Couples.FirstOrDefault(f => f.Function.FunctionName == "executor2")?.Employer?.Id ?? 0))
                .ForMember(dest => dest.EmployerName2, opt => opt.MapFrom((src, dest) =>
                    src.Couples.FirstOrDefault(f => f.Function.FunctionName == "executor2")?.Employer?.FullName ?? string.Empty))

                .ForMember(dest => dest.SupervisorRegistry, opt => opt.MapFrom((src, dest) =>
                    src.Couples.FirstOrDefault(f => f.Function.FunctionName == "supervisor")?.Employer?.Id ?? 0))
                .ForMember(dest => dest.SupervisorName, opt => opt.MapFrom((src, dest) =>
                    src.Couples.FirstOrDefault(f => f.Function.FunctionName == "supervisor")?.Employer?.FullName ?? string.Empty))
                    
                .ReverseMap();
        }
    }
}