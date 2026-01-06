using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Application.Mappers
{
    public class ProcessAutoMapper : Profile
    {
        public ProcessAutoMapper()
        {
            CreateMap<Process, ProcessDTO>().ReverseMap();
        }
    }
}