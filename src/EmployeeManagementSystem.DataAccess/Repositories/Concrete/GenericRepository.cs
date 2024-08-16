using EmployeeManagementSystem.DataAccess.Context;
using EmployeeManagementSystem.DataAccess.Repositories.Abstract;
using EmployeeManagementSystem.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.DataAccess.Repositories.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly EmployeeManagementSystemDbContext dbContext;

        public GenericRepository(EmployeeManagementSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        protected DbSet<TEntity> _entity => dbContext.Set<TEntity>();


        public virtual async Task<int> AddAsync(TEntity entity)
        {
            await this._entity.AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }


        public virtual async Task<TEntity> AddEntityAsync(TEntity entity)
        {
            await this._entity.AddAsync(entity);
            var res = await dbContext.SaveChangesAsync();
            return res > 0 ? entity : null;
        }



        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            this._entity.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;

            return await dbContext.SaveChangesAsync();
        }

        public virtual Task<int> DeleteAsync(TEntity entity)
        {
            if (dbContext.Entry(entity).State == EntityState.Detached)
            {
                this._entity.Attach(entity);
            }

            this._entity.Remove(entity);

            return dbContext.SaveChangesAsync();
        }

        public virtual IQueryable<TEntity> AsQueryable() => _entity.AsQueryable();


        public virtual async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _entity;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (noTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAll(bool noTracking = true)
        {
            if (noTracking)
                return await _entity.AsNoTracking().ToListAsync();

            return await _entity.ToListAsync();
        }

        private static IQueryable<TEntity> ApplyIncludes(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes)
        {
            if (includes != null)
            {
                foreach (var includeItem in includes)
                {
                    query = query.Include(includeItem);
                }
            }

            return query;
        }
        public async Task<List<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {

            IQueryable<TEntity> query = _entity;


            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }
        public virtual async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _entity;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            query = ApplyIncludes(query, includes);

            if (noTracking)
                query = query.AsNoTracking();

            return await query.SingleOrDefaultAsync();


        }

    }
}
