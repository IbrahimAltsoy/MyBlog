using Blog.Core.Entities;
using Blog.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task AddAsync(T entity)
        {// Task ile void aynı işlevi görüyor o yüzden bir şe ydönmesine gerek yoktur. voidin async halidir işte 
            await Table.AddAsync(entity);
        }
    }
}
