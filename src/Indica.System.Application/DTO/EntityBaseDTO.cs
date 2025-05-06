namespace Indica.System.Application.DTO
{
    public abstract class EntityBaseDTO
    {
        public virtual Dictionary<string, List<string>> Validate() => [];
    }
}
