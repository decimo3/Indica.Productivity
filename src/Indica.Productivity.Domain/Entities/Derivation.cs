namespace Indica.Productivity.Domain.Entities
{
    public class Derivation : EntityBase
    {
        public string DerivationName { get; set; }
        public virtual List<Selection> Selections { get; set; }
    }
}