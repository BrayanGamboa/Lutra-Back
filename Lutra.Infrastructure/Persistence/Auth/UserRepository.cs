using Lutra.Application.Auth.Ports;
using Lutra.Domain.Auth;
using Lutra.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence.Auth;

public class EfUserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public EfUserRepository(AppDbContext context) => _context = context;

    public async Task<User?> GetByUsernameAsync(string username) =>
        await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

    public async Task<User?> GetByEmailOrUserIdAsync(string email, Guid? userId) =>
        await _context.Users.FirstOrDefaultAsync(u => u.Email == email || u.UserId == userId);

    public async Task<bool> ExistAsync(string email, string username) =>
        await _context.Users.AnyAsync(u => u.Email == email || u.Username == username);

    public async Task<(IEnumerable<User> Items, int Total)> GetAllAsync(
        string? search, string? rol, int page, int pageSize)
    {
        var query = _context.Users
            .Include(u => u.RoleUsersDetails)
                .ThenInclude(rud => rud.Role)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.ToLower();
            query = query.Where(u =>
                u.Name.ToLower().Contains(term) ||
                u.LastName.ToLower().Contains(term) ||
                u.Username.ToLower().Contains(term));
        }

        if (!string.IsNullOrWhiteSpace(rol))
        {
            var rolTerm = rol.ToLower();
            query = query.Where(u =>
                u.RoleUsersDetails.Any(rud =>
                    rud.Role.Name.ToLower().Contains(rolTerm)));
        }

        var total = await query.CountAsync();
        var items = await query
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, total);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}