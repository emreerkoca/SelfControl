using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Self.Core.DTOs;
using Self.Core.Entities;
using Self.Core.Interfaces;
using Self.Core.Paging;
using Self.Infrastructure.Data;

namespace Self.Service
{
    public class WordService : IWordService
    {
        private IUnitOfWork _unitOfWork;
        private IMemoryCache _cache;

        public WordService(IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        {
            this._unitOfWork = unitOfWork as UnitOfWork;
            _cache = memoryCache;
        }

        public async Task<Word> AddWord(Word word)
        {
            try
            {
                _unitOfWork.WordRepository.Add(word);
                await _unitOfWork.CommitAsync();

                return word;
            }
            catch (Exception ex)
            {
                _unitOfWork.Dispose();

                return null;
            }
        }

        public async Task DeleteWord(Word word)
        {
            _unitOfWork.WordRepository.Delete(word);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Word> GetWordById(int id)
        {
            return await _unitOfWork.WordRepository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<Word>> GetWords(int userId, int isUpdated)
        {
            IReadOnlyList<Word> words;

            if (!_cache.TryGetValue("_Words", out words) || isUpdated == 1)
            {
                words = await _unitOfWork.WordRepository.GetListByUserAsync(userId);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30));

                _cache.Set("_Words", words, cacheEntryOptions);
            }
            else
            {
                words = _cache.Get<IReadOnlyList<Word>>("_Words");
            }
            return words;
        }

        public ItemListDTO<Word> GetWordsByRange(int userId, int isUpdated, PagingParameters pagingParameters)
        {
            return _unitOfWork.WordRepository.GetListByRange(userId, pagingParameters);
        }

        public async Task UpdateWord(Word word)
        {
            _unitOfWork.WordRepository.Update(word);

            await _unitOfWork.CommitAsync();
        }
    }
}
