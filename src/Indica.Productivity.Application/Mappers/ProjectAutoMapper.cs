using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Application.Mappers
{
    public class ProjectAutoMapper : Profile
    {
        public ProjectAutoMapper()
        {
            CreateMap<Project, ProjectDTO>().ReverseMap();
        }
    }
}