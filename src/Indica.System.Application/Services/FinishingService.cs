using AutoMapper;
using Indica.System.Application.DTO;
using Indica.System.Application.Interfaces;
using Indica.System.Domain.Entities;
using Indica.System.Domain.Interfaces;
using Indica.System.Shared.Interfaces;

namespace Indica.System.Application.Services
{
    public class FinishingService : BaseService<FinishingDTO, Finishing>, IFinishingService
    {
        private readonly IFinishingRepository finishingRepository;
        private readonly IFinishingDetailRepository detailRepository;
        private readonly IFinishingPaymentRepository paymentRepository;
        private readonly IPaymentMasterRepository paymentMasterRepository;

        public FinishingService
        (
            IMapper mapper,
            IFileParser fileParser,
            IFinishingRepository finishingRepository,
            IFinishingDetailRepository detailRepository,
            IFinishingPaymentRepository paymentRepository,
            IPaymentMasterRepository paymentMasterRepository
        ) : base(finishingRepository, mapper, fileParser)
        {
            this.finishingRepository = finishingRepository;
            this.detailRepository = detailRepository;
            this.paymentRepository = paymentRepository;
            this.paymentMasterRepository = paymentMasterRepository;
        }
        private async Task<List<Finishing>> GetFinishingAsync(List<FinishingDTO> entities)
        {
            if (entities is null || entities.Count == 0)
                throw new ArgumentException();
            var details = await detailRepository.GetAllAsync();
            var tasks = entities.Select(async entity =>
            {
                var detail = details.Where(d => d.Detail == entity.FinishingDetail).Single();
                var payments = new List<FinishingPayment>();
                foreach (var paymentMaster in entity.PaymentMasters.Split('/'))
                {
                    if (int.TryParse(paymentMaster, out int mestre))
                        throw new InvalidOperationException($"O mestre {paymentMaster} é inválido!");
                    var payment = await paymentRepository.GetSingleOrDefaultByExpressionAsync(
                        p => p.Mestre.Master == mestre) ??
                            throw new InvalidOperationException($"O mestre {mestre} não foi encontrado!");
                    payments.Add(payment);
                }
                return new Finishing
                {
                    GroupingOfMeasures = entity.GroupingOfMeasures,
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
