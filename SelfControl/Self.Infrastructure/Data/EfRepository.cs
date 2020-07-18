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
            await _appDbContext.Set<T>().AddAsync(entity);

            return  entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
            var saveResult = await _appDbContext.SaveChangesAsync();

            return saveResult == 1;
        }

        public bool Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
            var saveResult = _appDbContext.SaveChanges();

            return saveResult == 1;
        }

        public virtual T GetById(int id)
        {
            return _appDbContext.Set<T>().Find(id);
        }

        public virtual ValueTask<T> GetByIdAsync(int id)
        {
            return _appDbContext.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> GetList()
        {
            return _appDbContext.Set<T>().AsEnumerable();
        }

        public bool Update(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            var saveResult = _appDbContext.SaveChanges();

            return saveResult == 1;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            var saveResult = await _appDbContext.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<IReadOnlyList<T>> GetListAllAsync()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }
    }
}
