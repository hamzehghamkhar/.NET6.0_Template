using app.DataLayer.Context;
using app.DataLayer.Interfaces;
using app.Entities.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace app.DataLayer.Implementions
{
    public class Seed : ISeed
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ApplicationDbContext db;
        private readonly IUnitOfWork dbo;
        private readonly IUserRepository userRepository;
        private readonly IWebHostEnvironment env;
        private readonly IRolesRepository rolesRepository;
        public Seed(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.db = serviceProvider.GetService<ApplicationDbContext>();
            this.dbo = serviceProvider.GetService<IUnitOfWork>();
            this.env = serviceProvider.GetService<IWebHostEnvironment>();
            this.userRepository = serviceProvider.GetService<IUserRepository>();
            this.rolesRepository = serviceProvider.GetService<IRolesRepository>();
        }

        public void Inilialize()
        {
            try
            {
                Migrations();
                AddDefaultUser();
            }
            catch { }
        }

        #region AddDefaultUser
        private void AddDefaultUser()
        {
            try
            {
                var user = new ApplicationUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "administrator",
                    firstName = "مدیریت",
                    lastName = "سایت",
                    mobile = "09028738496",
                    PhoneNumber = "09028738496",
                    Email = "ghamkharhamzeh@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };
                if (!db.Users.Where(x => x.UserName.Equals(user.UserName)).Any())
                {
                    var r = userRepository.CreateAsync(user, "871251924").GetAwaiter().GetResult();
                    if (r.Succeeded)
                    {
                        userRepository.AddToClaimsAsync(user, new List<Claim>
                        {
                            new Claim(ClaimExtended._userId, user.Id)
                        }).GetAwaiter().GetResult();
                        userRepository.AddToRoleAsync(user, "administrator").GetAwaiter().GetResult();
                    }
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }
        #endregion

        #region Migrations
        private void Migrations()
        {
            try
            {
                if (db.Database.GetPendingMigrations().Any())
                {
                    db.Database.EnsureCreated();
                    db.Database.Migrate();
                }
            }
            catch
            {
            }
        }
        #endregion
    }
}
