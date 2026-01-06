namespace Indica.System.Domain.Entities
{
    public class Credential : EntityBase
    {
        public int IdEmployer { get; set; }
        public string PassHash { get; set; }
        public virtual Employer Employer { get; set; }
    }
}
