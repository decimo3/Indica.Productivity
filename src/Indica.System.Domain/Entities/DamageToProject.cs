namespace Indica.System.Domain.Entities
{
    public class DamageToProcess : EntityBase
    {
        public string Damage { get; set; }
        public string Description { get; set; }
        public string IdProject { get; set; }
    }
}