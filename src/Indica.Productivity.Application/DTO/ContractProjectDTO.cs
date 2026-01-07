using Indica.Productivity.Shared;

namespace Indica.Productivity.Application.DTO
{
    public class ContractProjectDTO : EntityBaseDTO
    {
        [Alias("Contrato")]
        public long Contract { get; set; }
        [Alias("Aditivo")]
        public int Additive { get; set; }
        [Alias("Projeto")]
        public string Project { get; set; }
        [Alias("Derivação")]
        public string Derivation { get; set; }
        [Alias("Regional")]
        public string Regional { get; set; }
    }
}
