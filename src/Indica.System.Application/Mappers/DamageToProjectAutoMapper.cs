using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Domain.Entities;

namespace Indica.System.Application.Mappers
{
    public class DamageToProjectAutoMapper : Profile
    {
        public DamageToProjectAutoMapper()
        {
            CreateMap<DamageToProcess, DamageToProjectDTO>().ReverseMap();
        }
    }
}