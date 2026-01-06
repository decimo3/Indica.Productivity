using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Application.Mappers
{
    public class ContractAutoMapper : Profile
    {
        public ContractAutoMapper()
        {
            CreateMap<Contract, ContractDTO>().ReverseMap();
        }
    }
}
