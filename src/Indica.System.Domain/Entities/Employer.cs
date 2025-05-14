namespace Indica.System.Domain.Entities
{
	public class Employer : EntityBase
	{
		public int Registry { get; set; }
		public string FullName { get; set; }
		public DateOnly Admission { get; set; }
		public DateOnly? Demission { get; set; }
		public int IdSituation { get; set; }
        public int IdRole { get; set; }
    }
}
