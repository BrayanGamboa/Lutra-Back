using Lutra.Domain.Auth;

namespace Lutra.Application.Auth.Ports
{
    public interface IRoleUsersDetailRepository
    {
        Task<RoleUsersDetail> AddRoleToUserAsync(Guid userId, int roleId);
        Task<IEnumerable<RoleUsersDetail>> GetRolesByUserIdAsync(Guid userId);
    }
}
