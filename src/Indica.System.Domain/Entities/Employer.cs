namespace Indica.System.Domain.Entities
{
	public class Employer : EntityBase
	{
        public int IndicaRegistry { get; set; }
        public int ClientRegistry { get; set; }
		public string FullName { get; set; }
		public DateOnly Admission { get; set; }
		public DateOnly? Demission { get; set; }
		public int IdSituation { get; set; }
        public int IdFunction { get; set; }
		public EmployerFunction Function { get; set; }
		public EmployerSituation Situation { get; set; }
    }
}
