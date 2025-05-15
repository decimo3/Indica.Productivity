namespace Indica.System.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public virtual Dictionary<string, List<string>> Validate() => [];
    }
}
