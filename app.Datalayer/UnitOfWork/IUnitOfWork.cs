using app.DataLayer.Interfaces;

namespace app.DataLayer.Context
{
    public interface IUnitOfWork : IDisposable
    {
        IEntityDataBaseTransaction BeginTransaction();
        IUserRepository Users { get; }
        IRolesRepository Roles { get; }
        void DbMigration();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
