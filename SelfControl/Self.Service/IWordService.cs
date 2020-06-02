using Self.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Self.Service
{
    public interface IWordService
    {
        Task<Word> AddWord(Word word);
        Task UpdateWord(Word word);
        Task DeleteWord(Word word);
        Task<IReadOnlyList<Word>> GetWords(int userId);
        Task<Word> GetWordById(int id);
        }
}
