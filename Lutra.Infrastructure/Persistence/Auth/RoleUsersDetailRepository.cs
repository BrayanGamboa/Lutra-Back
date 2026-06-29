using Lutra.Application.Auth.Ports;
using Lutra.Domain.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lutra.Infrastructure.Persistence.Auth
{
    public class EfRoleUsersDetailRepository: IRoleUsersDetailRepository
    {
        private readonly AppDbContext _context;
        public EfRoleUsersDetailRepository(AppDbContext context) => _context = context;

        public async Task<RoleUsersDetail> AddRoleToUserAsync(Guid userId, int roleId)
        {
            var roleUserDetail = new RoleUsersDetail
            {
                UserId = userId,
                RoleId = roleId,
                CreatedAt = DateTime.UtcNow
            };
            _context.UserRoles.Add(roleUserDetail);
            await _context.SaveChangesAsync();
            return roleUserDetail;
        }

        public async Task<IEnumerable<RoleUsersDetail>> GetRolesByUserIdAsync(Guid userId)
        {
            var roles = await (
                from ur in _context.UserRoles
                join r in _context.Roles on ur.RoleId equals r.RoleId
                where ur.UserId == userId
                select new RoleUsersDetail
                {
                    RoleId = ur.RoleId,
                    UserId = ur.UserId,
                    CreatedAt = ur.CreatedAt,
                    UpdatedAt = ur.UpdatedAt,
                    Role = new Role
                    {
                        RoleId = r.RoleId,
                        Name = r.Name,
                        Description = r.Description,    
                        CreatedAt = r.CreatedAt,
                        UpdatedAt = r.UpdatedAt
                    }
                }
            ).ToListAsync();

            return roles;
        }
    }
}
