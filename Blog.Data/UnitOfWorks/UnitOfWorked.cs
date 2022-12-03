using Blog.Data.Context;
using Blog.Data.Repositories.Abstractions;
using Blog.Data.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.UnitOfWork
{
    public class UnitOfWorked : IUnitOfWorked
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWorked(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async ValueTask DisposeAsync()
        {
           await _appDbContext.DisposeAsync();
        }

        public int Save()
        {
           return _appDbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _appDbContext.SaveChangesAsync(); 
        }

        IRepository<T> IUnitOfWorked.GetRepository<T>()
        {
            return new Repository<T>(_appDbContext);
        }
    }
}
