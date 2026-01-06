using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Domain.Entities;

namespace Indica.System.Application.Mappers
{
    public class ObjectiveAutoMapper : Profile
    {
        public ObjectiveAutoMapper()
        {
            CreateMap<Objective, ObjectiveDTO>().ReverseMap();
        }
    }
}