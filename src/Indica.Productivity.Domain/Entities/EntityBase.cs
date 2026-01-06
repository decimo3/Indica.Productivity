namespace Indica.Productivity.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public virtual Dictionary<string, List<string>> Validate() => [];
    }
}
