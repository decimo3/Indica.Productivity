using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Application.Mappers
{
    public class ObjectiveAutoMapper : Profile
    {
        public ObjectiveAutoMapper()
        {
            CreateMap<Objective, ObjectiveDTO>().ReverseMap();
        }
    }
}