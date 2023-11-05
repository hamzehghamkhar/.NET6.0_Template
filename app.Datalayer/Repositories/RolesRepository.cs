using app.DataLayer.Context;
using app.DataLayer.Generics;
using app.DataLayer.Interfaces;
using app.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace app.DataLayer.Repositories.Identity
{
    public class RolesRepository : GenericRepository<ApplicationRole>, IRolesRepository
    {
        #region Ctor
        private readonly ApplicationDbContext db;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public RolesRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
        public RolesRepository(ApplicationDbContext db, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) : base(db)
        {
            this.db = db;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        #endregion

        #region GetUsersInRoles
        public IEnumerable<string> GetUsersInRoles(string roleName)
        {
            var role = db.Roles.Where(x => x.Name == roleName).FirstOrDefault();
            return db.UserRoles.Where(x => x.RoleId.Equals(role.Id)).Select(s => s.UserId).AsNoTracking().AsEnumerable();
        }
        #endregion

        #region GetUserRoles
        public IEnumerable<string> GetUserRoles(string userId)
        {
            return db.UserRoles.Where(x => x.UserId.Equals(userId)).Select(s => s.RoleId).AsNoTracking().AsEnumerable();
        }
        #endregion

        #region IsInRole
        public async Task<bool> IsInRole(ApplicationUser user, string rolename)
        {
            return await _userManager.IsInRoleAsync(user, rolename);
        }
        #endregion

        #region AddToRolesAsync
        public async Task<IdentityResult> AddToRolesAsync(ApplicationUser user, IEnumerable<string> roles)
        {
            return await _userManager.AddToRolesAsync(user, roles);
        }
        #endregion

        #region AddToRoleAsync
        public async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string roleName)
        {
            if (!db.Roles.Where(x => x.Name == roleName).Any())
            {
                await CreateAsync(new ApplicationRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = roleName,
                    Descriptions = roleName,
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            }
            return await _userManager.AddToRoleAsync(user, roleName);
        }
        #endregion

        #region RemoveFromRoleAsync
        public async Task<IdentityResult> RemoveFromRoleAsync(ApplicationUser user, string role)
        {
            return await _userManager.RemoveFromRoleAsync(user, role);
        }
        #endregion

        #region RemoveFromRolesAsync
        public async Task<IdentityResult> RemoveFromRolesAsync(ApplicationUser user, string[] roles)
        {
            return await _userManager.RemoveFromRolesAsync(user, roles);
        }
        #endregion

        #region GetRolesAsync
        public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }
        #endregion

        #region GetUsersInRoleAsync
        public async Task<IList<ApplicationUser>> GetUsersInRoleAsync(string RoleName)
        {
            return await _userManager.GetUsersInRoleAsync(roleName: RoleName);
        }
        #endregion

        #region GetAllRole
        public List<ApplicationRole> GetAllRole()
        {
            return _roleManager.Roles.OrderBy(x => x.Name).ToList();
        }
        #endregion

        #region CreateAsync
        public async Task<IdentityResult> CreateAsync(ApplicationRole entry)
        {
            return await _roleManager.CreateAsync(entry);
        }
        #endregion

        #region GetAllRoles
        public IEnumerable<SelectListItem> GetAllRoles(string userId = null)
        {
            List<SelectListItem> selectListItem = new List<SelectListItem>();
            foreach (var item in db.Roles.OrderBy(x => x.Name).AsEnumerable())
            {
                selectListItem.Add(new SelectListItem()
                {
                    Value = item.Name,
                    Text = item.Descriptions,
                    Selected = db.UserRoles.Where(x => x.UserId.Equals(userId) && x.RoleId.Equals(item.Id)).Any(),
                });
            }
            return selectListItem.AsEnumerable();
        }
        #endregion

        #region ClearRolesAsync
        public async Task ClearRolesAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            foreach (string role in roles)
            {
                await _userManager.RemoveFromRoleAsync(user, role);
            }
        }
        #endregion

    }
}
