using Lutra.Application.Auth.Ports;
using Lutra.Domain.Auth;
using Lutra.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence.Auth;

public class EfRoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;

    public EfRoleRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Role>> GetAllAsync() =>
        await _context.Roles.ToListAsync();

    public async Task<Role?> GetByNameOrIdAsync(string name = null, int? roleId = null) =>
        await _context.Roles.FirstOrDefaultAsync(r => r.Name == name || r.RoleId == roleId);

    public async Task<bool> ExistAsync(string roleName) =>
        await _context.Roles.AnyAsync(r => r.Name == roleName); 

    public async Task AddAsync(Role role)
    {
        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Role role)
    {
        var tracked = await _context.Roles.FindAsync(role.RoleId) ?? throw new KeyNotFoundException($"Role {role.RoleId} not found");

        tracked.Update(role.RoleId, role.Name, role.Description);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Role role)
    {
        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
    }
}