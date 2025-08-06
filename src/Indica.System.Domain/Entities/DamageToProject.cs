namespace Indica.System.Domain.Entities
{
    public class DamageToProject : EntityBase
    {
        public string Damage { get; set; }
        public string Description { get; set; }
        public int IdProject { get; set; }
    }
}