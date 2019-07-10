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
    public class WordRepository : EfRepository<Word>, IWordRepository
    {
        public WordRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Word GetRandomWord()
        {
            return _appDbContext.Word.OrderBy(r => Guid.NewGuid()).Skip(2).Take(1).First();
        }

        public Task<Word> GetRandomWordAsync()
        {
            return _appDbContext.Word.OrderBy(r => Guid.NewGuid()).Skip(2).Take(1).FirstAsync();
        }

        public async Task<IReadOnlyList<Word>> GetListByUserAsync(string userName)
        {
            return await _appDbContext.Word.Where(x => x.OwnerId == userName).ToListAsync();
        }

    }
}
