using Lutra.Application.Auth.Ports;
using Lutra.Domain.Auth;

namespace Lutra.Infrastructure.Persistence.Auth;

public class EfUserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public EfUserRepository(AppDbContext context) => _context = context;

    public async Task<User?> GetByUsernameAsync(string username) =>
        await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

    public async Task<User?> GetByEmailAsync(string email) =>
        await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<bool> ExistsAsync(string username, string email) =>
        await _context.Users.AnyAsync(u => u.Username == username || u.Email == email);

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}