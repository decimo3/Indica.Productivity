using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Domain.Entities;

namespace Indica.System.Application.Mappers
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
