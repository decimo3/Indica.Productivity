namespace Indica.System.Shared
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class AliasAttribute : Attribute
    {
        public string Name { get; }
        public AliasAttribute(string name)
        {
            Name = name;
        }
    }
}