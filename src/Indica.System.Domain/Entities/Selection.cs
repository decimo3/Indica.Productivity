namespace Indica.System.Domain.Entities
{
    public class Selection : EntityBase
    {
        public string SelectionPattern { get; set; }
        public int IdDerivation { get; set; }
        public virtual Derivation Derivation { get; set; }
    }
}