namespace Indica.System.Application.DTO
{
    public abstract class EntityBaseDTO
    {
        public int Id { get; set; }
        public virtual Dictionary<string, List<string>> Validate() => [];
    }
}
