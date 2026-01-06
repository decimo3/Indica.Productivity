using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Application.Mappers
{
    public class CodeFilterAutoMapper : Profile
    {
        public CodeFilterAutoMapper()
        {
            CreateMap<CodeFilter, CodeFilterDTO>().ReverseMap();
        }
    }
}