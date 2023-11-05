using app.DataLayer.Generics;
using app.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.DataLayer.Interfaces
{
    public interface IRolesRepository : IGenericRepository<ApplicationRole>, IDisposable
    {
        IEnumerable<string> GetUsersInRoles(string roleName);
        IEnumerable<string> GetUserRoles(string userId);
        Task<bool> IsInRole(ApplicationUser user, string rolename);
        Task<IdentityResult> AddToRolesAsync(ApplicationUser user, IEnumerable<string> roles);
        Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string roleName);
        Task<IdentityResult> RemoveFromRoleAsync(ApplicationUser user, string role);
        Task<IdentityResult> RemoveFromRolesAsync(ApplicationUser user, string[] roles);
        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task<IList<ApplicationUser>> GetUsersInRoleAsync(string RoleName);
        List<ApplicationRole> GetAllRole();
        Task<IdentityResult> CreateAsync(ApplicationRole entry);
        IEnumerable<SelectListItem> GetAllRoles(string userId = null);
        Task ClearRolesAsync(ApplicationUser user);

    }
}
