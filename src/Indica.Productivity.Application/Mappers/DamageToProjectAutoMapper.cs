using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Application.Mappers
{
    public class DamageToProjectAutoMapper : Profile
    {
        public DamageToProjectAutoMapper()
        {
            CreateMap<DamageToProject, DamageToProjectDTO>().ReverseMap();
        }
    }
}