using app.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace app.DataLayer.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #region DbSets

        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var releationShip in builder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                releationShip.DeleteBehavior = DeleteBehavior.Cascade;
            }
            //builder.Entity<Products>(entity =>
            //{
            //    entity.OwnsOne(e => e.PackingDimension);
            //});
            //builder.Ignore<State>();
            //builder.Ignore<Towns>();
            base.OnModelCreating(builder);
        }
        #endregion

    }
}
