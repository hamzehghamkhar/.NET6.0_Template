using app.DataLayer.Interfaces;
using app.DataLayer.Repositories.Identity;
using app.DataLayer.Services;
using Microsoft.EntityFrameworkCore;

namespace app.DataLayer.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        public UnitOfWork(ApplicationDbContext db)
        {
            this.db = db;
        }



        #region BeginTransaction
        public IEntityDataBaseTransaction BeginTransaction()
        {
            return new EntityDataBaseTransaction(db);
        }
        #endregion

        #region Users
        private IUserRepository _Users;
        public IUserRepository Users
        {
            get
            {
                if (_Users == null)
                {
                    _Users = new UserRepository(db);
                }
                return _Users;
            }
        }
        #endregion

        #region Roles
        private IRolesRepository _Roles;
        public IRolesRepository Roles
        {
            get
            {
                if (_Roles == null)
                {
                    _Roles = new RolesRepository(db);
                }
                return _Roles;
            }
        }
        #endregion

        #region SaveChanges
        public int SaveChanges()
        {
            return db.SaveChanges();
        }
        #endregion

        #region SaveChangesAsync
        public async Task<int> SaveChangesAsync()
        {
            int result = await db.SaveChangesAsync();
            return result;
        }
        #endregion

        #region DbMigration
        public void DbMigration()
        {
            db.Database.Migrate();
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            db.Dispose();
        }
        #endregion


    }
}
