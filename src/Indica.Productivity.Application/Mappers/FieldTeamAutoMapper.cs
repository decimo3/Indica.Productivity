using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Application.Mappers
{
    public class FieldTeamAutoMapper : Profile
    {
        public FieldTeamAutoMapper()
        {
            CreateMap<FieldTeam, FieldTeamDTO>()
                .ForMember(dest => dest.WorkArea, opt => opt.MapFrom(src => src.Regional.RegionName))
                .ForMember(dest => dest.ActivityName, opt => opt.MapFrom(src => src.Activity.ActivityName))

                .ForMember(dest => dest.EmployerRegistry1, opt => opt.MapFrom((src, dest) =>
                    src.Couples.FirstOrDefault(f => f.Function.FunctionName == "executor1")?.Employer?.ClientRegistry ?? 0))
                .ForMember(dest => dest.EmployerName1, opt => opt.MapFrom((src, dest) =>
                    src.Couples.FirstOrDefault(f => f.Function.FunctionName == "executor1")?.Employer?.FullName ?? string.Empty))

                .ForMember(dest => dest.EmployerRegistry2, opt => opt.MapFrom((src, dest) =>
                    src.Couples.FirstOrDefault(f => f.Function.FunctionName == "executor2")?.Employer?.ClientRegistry ?? 0))
                .ForMember(dest => dest.EmployerName2, opt => opt.MapFrom((src, dest) =>
                    src.Couples.FirstOrDefault(f => f.Function.FunctionName == "executor2")?.Employer?.FullName ?? string.Empty))

                .ForMember(dest => dest.SupervisorRegistry, opt => opt.MapFrom((src, dest) =>
                    src.Couples.FirstOrDefault(f => f.Function.FunctionName == "supervisor")?.Employer?.ClientRegistry ?? 0))
                .ForMember(dest => dest.SupervisorName, opt => opt.MapFrom((src, dest) =>
                    src.Couples.FirstOrDefault(f => f.Function.FunctionName == "supervisor")?.Employer?.FullName ?? string.Empty))

                .ReverseMap();
        }
    }
}