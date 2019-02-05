using Microsoft.EntityFrameworkCore;
using Self.Core.Entities;
using Self.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self.Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _appDbContext;

        public EfRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public T Add(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
            _appDbContext.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
             await _appDbContext.SaveChangesAsync();

            return  entity;
        }

        public void Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
            _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public virtual T GetById(int id)
        {
            return _appDbContext.Set<T>().Find(id);
        }

        public virtual Task<T> GetByIdAsync(int id)
        {
            return _appDbContext.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> GetList()
        {
            return _appDbContext.Set<T>().AsEnumerable();
        }

        public async Task<IReadOnlyList<T>> GetListAsync()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
