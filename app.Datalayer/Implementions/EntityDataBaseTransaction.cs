using app.DataLayer.Context;
using app.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace app.DataLayer.Services
{
    public class EntityDataBaseTransaction : IEntityDataBaseTransaction
    {
        private readonly IDbContextTransaction _transaction;
        public EntityDataBaseTransaction(ApplicationDbContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void RollBack()
        {
            _transaction.Rollback();
        }


        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}
