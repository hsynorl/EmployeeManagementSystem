using EmployeeManagementSystem.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.DataAccess.Repositories.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {

        Task<int> AddAsync(TEntity entity);
        Task<TEntity> AddEntityAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        IQueryable<TEntity> AsQueryable();
        Task<List<TEntity>> GetAll(bool noTracking = true);
        Task<List<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);

    }
}
