using Microsoft.EntityFrameworkCore;
using Self.Core.Entities;
using Self.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;

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

        public async Task<IReadOnlyList<Word>> GetListByUserAsync(int userId)
        {
            return await _appDbContext.Word.Where(x => x.OwnerId == userId).ToListAsync();
        }

        //public async Task ExportToFileAsync(string filePath, IReadOnlyList<Word> words)
        //{
        //    TextWriter textWriter = new StreamWriter(File.Open(filePath, FileMode.Create), Encoding.UTF8);
        //    var csvWriter = new CsvWriter(textWriter);

        //    csvWriter.WriteRecords(words);
        //    textWriter.Close();
        //}
    }
}
