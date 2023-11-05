using app.DataLayer.Interfaces;
using System.Linq.Expressions;


namespace app.DataLayer.Generics
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<T> SearchBy<T>(IQueryable<T> query, string keyword, List<string> propertyNames = null);
        X.PagedList.PagedList<T> PagedList<T>(IQueryable<T> query, int page = 1, int pagesize = 10);
        TEntity Find(object id);
        Task<TEntity> FindAsync(object id);
        void Add(TEntity entry);
        Task AddEntityAsync(TEntity entry);
        void EditEntity(TEntity entry);
        Task AddRangeAsync(List<TEntity> entry);
        void AddRange(List<TEntity> entry);
        void DeleteEntity(TEntity entry);
        void RemoveRange(IEnumerable<TEntity> entry);
        IQueryable<TEntity> GetQuery();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter);
        bool Any();
        bool Any(Expression<Func<TEntity, bool>> filter);
        Task SaveChangesAsync();
        IEntityDataBaseTransaction BeginTransaction();

    }
}
