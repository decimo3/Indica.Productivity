using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Domain.Entities;

namespace Indica.System.Application.Mappers
{
    public class SupervisorAutoMapper : Profile
    {
        public SupervisorAutoMapper()
        {
            CreateMap<SupervisorDTO, Supervisor>().ReverseMap();
        }
    }
}
