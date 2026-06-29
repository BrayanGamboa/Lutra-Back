using Lutra.Domain.Auth;

namespace Lutra.Application.Auth.Ports
{
    public interface IRoleRepository
    {
        Task<Role?> GetByNameOrIdAsync(string name = null, int? roleId = null);
        Task<IEnumerable<Role>> GetAllAsync();
        Task<bool> ExistAsync(string name);
        Task AddAsync(Role role);
        Task UpdateAsync(Role role);
        Task DeleteAsync(Role role);
    }
}
