using Indica.Productivity.Domain.Entities;

namespace Indica.Productivity.Application.Interfaces
{
    public interface ICredentialService
    {
        Task<string> GetPassHash(string password);
        Task<Employer?> ValidateUser(int registry, string password);
        Task<string> GenerateToken(Employer user);
        Task<Employer?> ValidateToken(string token);
    }
}

