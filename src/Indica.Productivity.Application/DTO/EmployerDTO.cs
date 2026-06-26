using Indica.Productivity.Application.Common.Validators;
using Indica.Productivity.Shared;

namespace Indica.Productivity.Application.DTO
{
    public class EmployerDTO : EntityBaseDTO
    {
        private static readonly int ACTIVE_STATUS = 1;
        [Alias("matricula_indica")]
        public int IndicaRegistry { get; set; }
        [Alias("matricula_light")]
        public int ClientRegistry { get; set; }
        [Alias("nome")]
		public string FullName { get; set; }
        [Alias("data_admissao")]
		public DateOnly Admission { get; set; }
        public DateOnly? Demission { get; set; } = null;
        public int IdSituation { get; set; } = ACTIVE_STATUS;
        [Alias("cargo")]
        public int IdFunction { get; set; }

        //public Dictionary<string, List<string>> Validate(Employer employer)
        //{
        //    ValidateRules(employer);
        //    ValidateDate(employer);
        //}
        public override Dictionary<string, List<string>> Validate()
        {
            var regras = new Dictionary<string, List<ValidatorModel>>
            {
                { "Registry", new List<ValidatorModel> { ValidatorRules.RegistryValidator } },
                { "Name", new List<ValidatorModel> { ValidatorRules.FullNameValidator } }
            };
            return ValidationHelper.ValidateObjectFields(this, regras);
        }
        private List<string> ValidateDate()
        {
            var hoje = DateOnly.FromDateTime(DateTime.Today);
            return new List<string>
            {
                this.Admission == DateOnly.MinValue ? "A data de admissão não pode ser nula!" : string.Empty,
                this.Admission >= hoje ? "A data de admissão não pode ser futura!" : string.Empty,
                this.Demission >= hoje ? "A data de demissão não pode ser futura!" : string.Empty,
                this.Demission == this.Admission ? "A data de admissão e demissão não podem ser iguais!" : string.Empty,
                this.Demission < this.Admission ? "A data de demissão não pode ser menor que a data de admissão!" : string.Empty
            }.Where(msg => string.IsNullOrEmpty(msg)).ToList();
        }
    }
}
