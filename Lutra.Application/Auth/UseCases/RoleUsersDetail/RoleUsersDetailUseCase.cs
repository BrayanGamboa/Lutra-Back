using Lutra.Application.Auth.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Auth.UseCases.RoleUsersDetail
{
    public class RoleUsersDetailUseCase
    {
        private readonly IRoleUsersDetailRepository _roleUsersDetailRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public RoleUsersDetailUseCase(IRoleUsersDetailRepository roleUsersDetailRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _roleUsersDetailRepository = roleUsersDetailRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<RoleUsersDetailResponse> GetRoleUsersDetailAsync(Guid userId)
        {
            var roles = await _roleUsersDetailRepository.GetRolesByUserIdAsync(userId) ?? throw new DomainException("Roles not found");

            var user = await _userRepository.GetByEmailOrUserIdAsync(null, userId) ?? throw new DomainException("User not found");

            return RoleUsersDetailResponse.FromDomain(user, roles);
        }

        public async Task<RoleUsersDetailResponse> AddRoleToUserAsync(Guid userId, int roleId)
        {
            var user = await _userRepository.GetByEmailOrUserIdAsync(null, userId) ?? throw new DomainException("User not found");
            var role = await _roleRepository.GetByNameOrIdAsync(roleId: roleId) ?? throw new DomainException("Role not found");
            await _roleUsersDetailRepository.AddRoleToUserAsync(userId, roleId);
            var roles = await _roleUsersDetailRepository.GetRolesByUserIdAsync(userId) ?? throw new DomainException("Roles not found");
            return RoleUsersDetailResponse.FromDomain(user, roles);
        }

    }
}