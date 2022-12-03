using Blog.Core.Entities;
using Blog.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repositories.Concretes
{
    public class Repository<T>:IRepository<T> where T : class,IEntityBase,new()
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        private DbSet<T>Table { get => _dbContext.Set<T>(); }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate=null, params Expression<Func<T,object>>[] includeProporties)
        {
            IQueryable<T> query = Table;
            if(predicate != null)
                query= query.Where(predicate);
            if(includeProporties.Any())
                foreach (var item in includeProporties)
                {
                    query = query.Include(item);
                }
            return await query.ToListAsync();
        }
        public async Task AddAsync(T entity)
        {// Task ile void aynı işlevi görüyor o yüzden bir şey dönmesine gerek yoktur. voidin async halidir işte 
            await Table.AddAsync(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate , params Expression<Func<T, object>>[] includeProporties)
        {
            IQueryable<T> query = Table;

            query= query.Where(predicate);

            if (includeProporties.Any())
                foreach (var item in includeProporties)
                {
                    query = query.Include(item);
                }

            return await query.SingleAsync();

        }

        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run (() => Table.Update(entity));
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
           
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
           return await CountAsync(predicate);
        }
    }
}
