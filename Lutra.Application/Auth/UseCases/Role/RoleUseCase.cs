using Lutra.Application.Auth.Ports;
using Lutra.Domain.Auth;
using Lutra.Domain.Shared;

namespace Lutra.Application.Auth.UseCases.Role;

public class RoleUseCase
{
    private readonly IRoleRepository _roleRepository;

    public RoleUseCase(
        IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<RoleResponse> GetByNameAsync(string roleName, int? roleId = null)
    {
        var role = await _roleRepository.GetByNameOrIdAsync(roleName, roleId);
        if (role == null)
        {
            throw new DomainException("El rol no existe");
        }
        return RoleResponse.FromDomain(role);
    }

    public async Task<IEnumerable<RoleResponse>> GetAllAsync()
    {
        var roles = await _roleRepository.GetAllAsync();
        return roles.Select(r => RoleResponse.FromDomain(r));
    }

    public async Task<RoleResponse> ExecuteAsync(RoleRequest request)
    {
        var roleExists = await _roleRepository.ExistAsync(request.Name);

        if (roleExists)
        {
            throw new DomainException("El rol ya existe");
        }

        var role = Domain.Auth.Role.Create(
            request.Name,
            request.Description
        );
        await _roleRepository.AddAsync(role);

        return RoleResponse.FromDomain(role);
    }

    public async Task<RoleResponse> UpdateAsync(int roleId, RoleRequest request)
    {
        var role = await _roleRepository.GetByNameOrIdAsync(roleId: roleId);
        if (role == null)
        {
            throw new DomainException("El rol no existe");
        }
        role.Update(
            roleId,
            request.Name,
            request.Description
        );
        await _roleRepository.UpdateAsync(role);
        return RoleResponse.FromDomain(role);
    }

    public async Task DeleteAsync(int roleId)
    {
        var role = await _roleRepository.GetByNameOrIdAsync(roleId: roleId);
        if (role == null)
        {
            throw new DomainException("El rol no existe");
        }
        await _roleRepository.DeleteAsync(role);
    }
}
