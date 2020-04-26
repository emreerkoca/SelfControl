using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Self.Core.Entities;
using Self.Core.Interfaces;

namespace Self.Service
{
    public class WordService : IWordService
    {
        private IUnitOfWork _unitOfWork;

        public WordService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Word> AddWord(Word word)
        {
            await _unitOfWork.Words.AddAsync(word);
            await _unitOfWork.CommitAsync();

            return word;
        }

        public async Task DeleteWord(Word word)
        {
            await _unitOfWork.Words.DeleteAsync(word);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Word> GetWordById(int id)
        {
            return await _unitOfWork.Words.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<Word>> GetWords()
        {
            return await _unitOfWork.Words.GetListAllAsync();
        }

        public async Task UpdateWord(Word word)
        {
            await _unitOfWork.Words.UpdateAsync(word);
            await _unitOfWork.CommitAsync();
        }
    }
}
