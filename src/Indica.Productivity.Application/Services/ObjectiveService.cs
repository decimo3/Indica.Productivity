using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;
using Indica.System.Shared.Interfaces;

namespace Indica.System.Application.Services
{
    public class ObjectiveService : BaseService<ObjectiveDTO, Objective>, IObjectiveService
    {
        public ObjectiveService(IObjectiveRepository repository, IMapper mapper, IFileParser parser) : base(repository, mapper, parser)
        {

        }
    }
}
