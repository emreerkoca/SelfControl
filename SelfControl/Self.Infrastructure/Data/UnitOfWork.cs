using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Self.Core.Interfaces;
using Self.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Self.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly IOptions<AppSettings>_appSettings;
        private IWordRepository _wordRepository;
        private IUserRepository _userRepository;
        public UnitOfWork(AppDbContext appDbContext, IOptions<AppSettings> appSettings)
        {
            _appDbContext = appDbContext;
            _appSettings = appSettings;

        }

        public IWordRepository WordRepository
        {
            get { return _wordRepository = _wordRepository ?? new WordRepository(this._appDbContext); }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository = _userRepository ?? new UserRepository(this._appDbContext, this._appSettings); }
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
