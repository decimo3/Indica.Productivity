using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Domain.Entities;

namespace Indica.System.Application.Mappers
{
    public class ProcessAutoMapper : Profile
    {
        public ProcessAutoMapper()
        {
            CreateMap<Process, ProcessDTO>().ReverseMap();
        }
    }
}