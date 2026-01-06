namespace Indica.Productivity.Shared.Interfaces
{
    public interface IFileParser
    {
        public List<T> ParseByFilepath<T>(string filepath) where T : new();
        public List<T> ParseByFilepath<T>(Stream stream, string filename) where T : new();
    }
}
