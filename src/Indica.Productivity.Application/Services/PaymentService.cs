using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;
using Indica.Productivity.Shared.Interfaces;

namespace Indica.Productivity.Application.Services
{
    public class PaymentService : BaseService<PaymentDTO, Payment>, IPaymentService
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly IContractProjectRepository contractProjectRepository;
        private readonly IPaymentMasterRepository paymentMasterRepository;
        public PaymentService
        (
            IMapper mapper,
            IFileParser parser,
            IPaymentRepository paymentRepository,
            IContractProjectRepository contractProjectRepository,
            IPaymentMasterRepository paymentMasterRepository
        ) : base(paymentRepository, mapper, parser)
        {
            this.paymentRepository = paymentRepository;
            this.contractProjectRepository = contractProjectRepository;
            this.paymentMasterRepository = paymentMasterRepository;
        }
        private async Task<List<Payment>> GetPaymentAsync(List<PaymentDTO> entities)
        {
            var contractProjects = await contractProjectRepository.GetAllAsync();
            var paymentMasters = await paymentMasterRepository.GetAllAsync();
            return entities.Select(e =>
            {
                var idContractProject = contractProjects.Single(c =>
                    c.Contract.ContractNumber == e.ContractNumber &&
                    c.Contract.AdditiveNumber == e.AdditiveNumber &&
                    c.Derivation.DerivationName == e.Derivation &&
                    c.Project.ProjectName == e.ProjectName).Id;
                var idPaymentMaster = paymentMasters.Single(m => m.Master == e.Master).Id;
                return new Payment()
                {
                    IdContractProject = idContractProject,
                    IdPaymentMaster = idPaymentMaster,
                    Valuation = e.Valuation
                };
            }).ToList();
        }
        public override async Task<bool> AddAsync(PaymentDTO entity)
        {
            var convertedEntities = await GetPaymentAsync([entity]);
            return await paymentRepository.AddAsync(convertedEntities.Single());
        }
        public override async Task<int> AddRangeAsync(List<PaymentDTO> entities)
        {
            var convertedEntities = await GetPaymentAsync(entities);
            return await paymentRepository.AddRangeAsync(convertedEntities);
        }
        public override async Task<bool> UpdateAsync(PaymentDTO entity)
        {
            var convertedEntities = await GetPaymentAsync([entity]);
            return await paymentRepository.UpdateAsync(convertedEntities.Single());
        }
        public override async Task<int> UpdateRangeAsync(List<PaymentDTO> entities)
        {
            var convertedEntities = await GetPaymentAsync(entities);
            return await paymentRepository.UpdateRangeAsync(convertedEntities);
        }
    }
}
