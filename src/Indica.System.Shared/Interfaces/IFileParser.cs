namespace Indica.System.Shared.Interfaces
{
    public interface IFileParser
    {
        public List<T> ParseByFilepath<T>(string filepath) where T : new();
    }
}
