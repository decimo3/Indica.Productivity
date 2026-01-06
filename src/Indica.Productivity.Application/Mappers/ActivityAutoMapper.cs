using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Application.Mappers
{
    public class ActivityAutoMapper : Profile
    {
        public ActivityAutoMapper()
        {
            CreateMap<Activity, ActivityDTO>().ReverseMap();
        }
    }
}