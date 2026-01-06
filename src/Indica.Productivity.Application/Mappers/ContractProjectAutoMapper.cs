using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Application.Mappers
{
    public class ContractProjectAutoMapper : Profile
    {
        public ContractProjectAutoMapper()
        {
            CreateMap<ContractProject, ContractProjectDTO>().ReverseMap();
        }
    }
}
