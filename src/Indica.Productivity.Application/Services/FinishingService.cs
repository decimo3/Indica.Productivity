using AutoMapper;
using Indica.Productivity.Application.DTO;
using Indica.Productivity.Application.Interfaces;
using Indica.Productivity.Domain.Entities;
using Indica.Productivity.Domain.Interfaces;
using Indica.Productivity.Shared.Interfaces;

namespace Indica.Productivity.Application.Services
{
    public class FinishingService : BaseService<FinishingDTO, Finishing>, IFinishingService
    {
        private readonly IFinishingRepository finishingRepository;
        private readonly IFinishingDetailRepository detailRepository;
        private readonly IPaymentMasterRepository paymentMasterRepository;

        public FinishingService
        (
            IMapper mapper,
            IFileParser fileParser,
            IFinishingRepository finishingRepository,
            IFinishingDetailRepository detailRepository,
            IPaymentMasterRepository paymentMasterRepository
        ) : base(finishingRepository, mapper, fileParser)
        {
            this.finishingRepository = finishingRepository;
            this.detailRepository = detailRepository;
            this.paymentMasterRepository = paymentMasterRepository;
        }
        private async Task<List<Finishing>> GetFinishingAsync(List<FinishingDTO> entities)
        {
            if (entities is null || entities.Count == 0)
                throw new ArgumentException();
            var details = await detailRepository.GetAllAsync();
            var tasks = entities.Select(async entity =>
            {
                var detail = details.Single(d => d.Detail == entity.FinishingDetail);
                var payments = new List<FinishingPayment>();
                foreach (var paymentMaster in entity.PaymentMasters.Split('/'))
                {
                    if (string.IsNullOrEmpty(paymentMaster)) continue;
                    if (!int.TryParse(paymentMaster, out int mestre))
                        throw new InvalidOperationException($"O mestre {paymentMaster} é inválido!");
                    if (mestre == 0) continue;
                    var master = await paymentMasterRepository.GetSingleOrDefaultByExpressionAsync(m => m.Master == mestre) ??
                        throw new InvalidOperationException($"O mestre {mestre} não foi encontrado!");
                    payments.Add(new FinishingPayment() { IdMaster = master.Id });
                }
                return new Finishing
                {
                    GroupingOfMeasures = entity.GroupingOfMeasures,
                    IsAlternative = entity.IsAlternative,
                    IdFinishingDetail = detail.Id,
                    Payments = payments
                };
            });
            return (await Task.WhenAll(tasks)).ToList();
        }
        public override async Task<bool> AddAsync(FinishingDTO entity)
        {
            var converted = await GetFinishingAsync([entity]);
            return await finishingRepository.AddAsync(converted.Single());
        }

        public override async Task<int> AddRangeAsync(List<FinishingDTO> lista)
        {
            var converted = await GetFinishingAsync(lista);
            return await finishingRepository.AddRangeAsync(converted);
        }

        public override async Task<bool> UpdateAsync(FinishingDTO entity)
        {
            var converted = await GetFinishingAsync([entity]);
            return await finishingRepository.UpdateAsync(converted.Single());
        }

        public override async Task<int> UpdateRangeAsync(List<FinishingDTO> lista)
        {
            var converted = await GetFinishingAsync(lista);
            return await finishingRepository.UpdateRangeAsync(converted);
        }
    }
}
