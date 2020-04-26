using Self.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Self.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private WordRepository _wordRepository;
        public UnitOfWork(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;

            Words = new WordRepository(_appDbContext);
        }

        //public IWordRepository Words => _wordRepository ??= new WordRepository(_appDbContext);
        public IWordRepository Words { get; private set; }

        public async Task<int> CommitAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
