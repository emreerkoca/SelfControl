using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Self.Core.Entities;
using Self.Core.Interfaces;
using Self.Infrastructure.Data;

namespace Self.Service
{
    public class WordService : IWordService
    {
        private IUnitOfWork _unitOfWork;
        public WordService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork as UnitOfWork;
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

        public async Task<IReadOnlyList<Word>> GetWords(int userId)
        {
            return await _unitOfWork.WordRepository.GetListByUserAsync(userId);
        }

        public async Task UpdateWord(Word word)
        {
            _unitOfWork.WordRepository.Update(word);

            await _unitOfWork.CommitAsync();
        }
    }
}
