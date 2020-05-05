using Microsoft.Extensions.Configuration;
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
        public IConfiguration _configuration { get; }
        private IWordRepository _wordRepository;
        private IUserRepository _userRepository;
        public UnitOfWork(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;

        }

        public IWordRepository WordRepository
        {
            get { return _wordRepository = _wordRepository ?? new WordRepository(this._appDbContext); }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository = _userRepository ?? new UserRepository(this._appDbContext, this._configuration); }
        }

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
