using Self.Core.Entities;
using Self.Core.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Self.Core.Interfaces
{
    public interface IWordRepository : IRepository<Word>, IAsyncRepository<Word>
    {
        Word GetRandomWord();
        Task<Word> GetRandomWordAsync();
        Task<IReadOnlyList<Word>> GetListByUserAsync(int userId);
        Task<PagedItemList<Word>> GetListByRangeAsync(int userId, PagingParameters pagingParameters);

        //Task ExportToFileAsync(string filePath, IReadOnlyList<Word> words);
    }
}
