using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Domain.Entities;

namespace Indica.System.Application.Mappers
{
    public class ProjectAutoMapper : Profile
    {
        public ProjectAutoMapper()
        {
            CreateMap<Project, ProjectDTO>().ReverseMap();
        }
    }
}