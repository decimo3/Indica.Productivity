using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Application.Mappers
{
    public class FinishingAutoMapper : Profile
    {
        public FinishingAutoMapper()
        {
            CreateMap<Finishing, FinishingDTO>()
                .ForMember(dest => dest.GroupingOfMeasures, opt => opt.MapFrom(src => src.GroupingOfMeasures))
                .ForMember(dest => dest.FinishingDetail, opt => opt.MapFrom(src => src.Detail.Detail))
                .ForMember(dest => dest.PaymentMasters, opt => opt.MapFrom(src => string.Join('/', src.Payments.Select(p => p.Master).ToList())));
        }
    }
}
