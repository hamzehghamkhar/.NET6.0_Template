using app.DataLayer.Context;
using app.DataLayer.Interfaces;
using app.DataLayer.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace app.DataLayer.Generics
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<TEntity>();
        }

        #region SearchBy
        /// <summary>
        /// A generic method that searches by each property of a model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="keyword"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public IQueryable<T> SearchBy<T>(IQueryable<T> query, string keyword, List<string> propertyNames = null)
        {
            // Create an empty result list
            List<T> result = new List<T>();
            // Get the type of the model
            Type modelType = typeof(T);
            // If no property names are specified, use all public properties
            if (propertyNames == null)
            {
                propertyNames = new List<string>();
                foreach (PropertyInfo prop in modelType.GetProperties())
                {
                    propertyNames.Add(prop.Name);
                }
            }
            // Loop through the models
            foreach (T model in query)
            {
                // Loop through the property names
                foreach (string propertyName in propertyNames)
                {
                    // Get the property info object
                    PropertyInfo prop = modelType.GetProperty(propertyName);

                    // If the property exists and is readable
                    if (prop != null && prop.CanRead)
                    {
                        var value = prop.GetValue(model);
                        Type type = prop.GetType();

                        if (value != null && value is string)
                        {
                            string valueString = value.ToString();
                            if (valueString.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                result.Add(model);
                                break;
                            }
                        }

                        if (value != null && value is long)
                        {
                            long valueNumber = long.Parse(value.ToString());
                            if (long.TryParse(keyword, out long num))
                            {
                                if (valueNumber == num)
                                {
                                    // Add the model to the result list
                                    result.Add(model);
                                    // Break out of the inner loop
                                    break;
                                }
                            }
                        }

                        if (value != null && value is int)
                        {
                            var valueNumber = int.Parse(value.ToString());
                            if (int.TryParse(keyword, out int num))
                            {
                                if (valueNumber == num)
                                {
                                    // Add the model to the result list
                                    result.Add(model);
                                    // Break out of the inner loop
                                    break;
                                }
                            }
                        }

                        if (value != null && value is double)
                        {
                            var valueNumber = double.Parse(value.ToString());
                            if (double.TryParse(keyword, out double num))
                            {
                                if (valueNumber == num)
                                {
                                    // Add the model to the result list
                                    result.Add(model);
                                    // Break out of the inner loop
                                    break;
                                }
                            }
                        }

                        if (value != null && value is float)
                        {
                            var valueNumber = float.Parse(value.ToString());
                            if (float.TryParse(keyword, out float num))
                            {
                                if (valueNumber == num)
                                {
                                    // Add the model to the result list
                                    result.Add(model);
                                    // Break out of the inner loop
                                    break;
                                }
                            }
                        }

                        if (value != null && value is decimal)
                        {
                            var valueNumber = decimal.Parse(value.ToString());
                            if (decimal.TryParse(keyword, out decimal num))
                            {
                                if (valueNumber == num)
                                {
                                    // Add the model to the result list
                                    result.Add(model);
                                    // Break out of the inner loop
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            // Return the result list
            return result.AsQueryable();
        }
        #endregion

        #region YesNo
        public SelectList YesNo(bool? value, string TrueText = "بله", string FalseText = "خیر")
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = TrueText, Value = true.ToString() });
            items.Add(new SelectListItem() { Text = FalseText, Value = false.ToString() });
            return new SelectList(items, "Value", "Text", value.ToString());
        }
        #endregion

        #region PagedList
        public virtual X.PagedList.PagedList<T> PagedList<T>(IQueryable<T> query, int page = 1, int pagesize = 10)
        {
            return new X.PagedList.PagedList<T>(query, page, pagesize);
        }
        #endregion

        #region Find
        public virtual TEntity Find(object id)
        {
            return _dbSet.Find(id);
        }
        #endregion

        #region FindAsync
        public virtual async Task<TEntity> FindAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }
        #endregion

        #region Where
        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter);
        }
        #endregion

        #region Any
        public virtual bool Any()
        {
            return _dbSet.Any();
        }
        #endregion

        #region Any
        public virtual bool Any(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Any(filter);
        }
        #endregion

        #region Add
        public virtual void Add(TEntity entry)
        {
            _dbSet.Add(entry);
        }
        #endregion

        #region AddEntityAsync
        public virtual async Task AddEntityAsync(TEntity entry)
        {
            await _dbSet.AddAsync(entry);
        }
        #endregion

        #region AddRangeAsync
        public virtual async Task AddRangeAsync(List<TEntity> entry)
        {
            await _dbSet.AddRangeAsync(entry);
        }
        #endregion

        #region AddRange
        public virtual void AddRange(List<TEntity> entry)
        {
            _dbSet.AddRange(entry);
        }
        #endregion

        #region EditEntity
        public virtual void EditEntity(TEntity entry)
        {
            _dbSet.Update(entry);
        }
        #endregion

        #region DeleteEntity
        public virtual void DeleteEntity(TEntity entry)
        {
            _dbSet.Remove(entry);
        }
        #endregion

        #region RemoveRange
        public virtual void RemoveRange(IEnumerable<TEntity> entry)
        {
            _dbSet.RemoveRange(entry);
        }
        #endregion

        #region GetQuery
        public virtual IQueryable<TEntity> GetQuery()
        {
            return _dbSet.AsQueryable();
        }
        #endregion

        #region SaveChangesAsync
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        #endregion

        #region BeginTransaction
        public IEntityDataBaseTransaction BeginTransaction()
        {
            return new EntityDataBaseTransaction(_context);
        }
        #endregion

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
