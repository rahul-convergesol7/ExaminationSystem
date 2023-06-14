using ES.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Repository.Operation
{
    public interface IUser
    {
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task<bool> UserIsInRoleAsync(ApplicationUser user, string role);
        Task<bool> CreateRoleAsync(ApplicationRole role);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);

        Task<bool> RoleExistAsync(string roleName);
        Task<IdentityResult> AddUserToRoleAsync(ApplicationUser user, string role);
 
    }
}
