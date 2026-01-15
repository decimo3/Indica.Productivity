using Indica.Productivity.Shared;

namespace Indica.Productivity.Application.DTO
{
    public class PaymentDTO : EntityBaseDTO
    {
        [Alias("Contrato")]
        public long ContractNumber { get; set; }
        [Alias("Aditivo")]
        public int AdditiveNumber { get; set; }
        [Alias("Regional")]
        public string Regional { get; set; }
        [Alias("Projeto")]
        public string ProjectName { get; set; }
        [Alias("Derivação")]
        public string Derivation { get; set; }
        [Alias("Mestre")]
        public int Master { get; set; }
        [Alias("Valor")]
        public decimal Valuation { get; set; }
    }
}
