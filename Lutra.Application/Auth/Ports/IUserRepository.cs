using Lutra.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lutra.Application.Auth.Ports
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
        Task<bool> ExistAsync(string email, string username);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
