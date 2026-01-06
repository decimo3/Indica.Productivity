using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Domain.Entities;

namespace Indica.System.Application.Mappers
{
    public class ContractAutoMapper : Profile
    {
        public ContractAutoMapper()
        {
            CreateMap<Contract, ContractDTO>().ReverseMap();
        }
    }
}
