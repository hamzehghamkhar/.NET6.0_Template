using app.DataLayer.Generics;
using app.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace app.DataLayer.Interfaces
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>, IDisposable
    {
        int userCount();
        Task ClearRolesAsync(ApplicationUser user);
        IEnumerable<SelectListItem> GetRoleList(string userId = null);
        Task<bool> IsInRole(ApplicationUser user, string rolename);
        Task<IdentityResult> AddToRolesAsync(ApplicationUser user, IEnumerable<string> roles);
        Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string roleName);
        Task<IdentityResult> RemoveFromRoleAsync(ApplicationUser user, string role);
        Task<IdentityResult> RemoveFromRolesAsync(ApplicationUser user, string[] roles);
        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task<IList<ApplicationUser>> GetUsersInRoleAsync(string RoleName);
        List<ApplicationRole> GetAllRole();
        Task<IdentityResult> CreateAsync(ApplicationRole entry);
        IEnumerable<string> GetUserRoles(string userId);
        IEnumerable<string> GetUsersInRoles(string roleName);
        Task<SignInResult> LoginAsync(string userName, string password, bool rememberMe, bool lockoutOnFailure);
        Task SignInAsync(ApplicationUser user, bool isPersistent);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword);
        Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string newPassword);
        Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string newPassword);
        Task<string> GenerateToken(ApplicationUser user);
        Task<IList<Claim>> GetClaimsAsync(ApplicationUser user);
        Task AddToClaimsAsync(ApplicationUser user, List<Claim> claims);
        Task RemoveClaimsAsync(ApplicationUser user, List<Claim> claims);
        Task RemoveClaimAsync(ApplicationUser user, Claim claim);
        Task signOutAsync();
    }
}
