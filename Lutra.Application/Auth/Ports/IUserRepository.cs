using Lutra.Domain.Auth;

namespace Lutra.Application.Auth.Ports
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailOrUserIdAsync(string email, Guid? userId);
        Task<bool> ExistAsync(string email, string username);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
