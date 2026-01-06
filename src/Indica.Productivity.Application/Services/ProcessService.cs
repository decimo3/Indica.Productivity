using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;
using Indica.Productivity.Shared.Interfaces;

namespace Indica.Productivity.Application.Services
{
    public class ProcessService : BaseService<ProcessDTO, Process>, IProcessService
    {
        public ProcessService(IProcessRepository repository, IMapper mapper, IFileParser parser) : base(repository, mapper, parser)
        {

        }
    }
}
