using Self.Core.Entities;
using Self.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Self.Infrastructure.Data
{
    public class WordRepository : EfRepository<Word>, IWordRepository
    {
        public WordRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
