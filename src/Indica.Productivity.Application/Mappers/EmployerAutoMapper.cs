using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Application.Mappers
{
    public class EmployerAutoMapper : Profile
    {
        public EmployerAutoMapper()
        {
            CreateMap<EmployerDTO, Employer>().ReverseMap();
        }
    }
}