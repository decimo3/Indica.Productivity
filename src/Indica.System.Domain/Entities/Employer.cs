namespace Indica.System.Domain.Entities
{
	public class Employer : EntityBase
	{
		public int Registry { get; set; }
		public string Name { get; set; }
		public DateOnly Admission { get; set; }
		public DateOnly? Demission { get; set; }
		public string Situation { get; set; }
    }
}
