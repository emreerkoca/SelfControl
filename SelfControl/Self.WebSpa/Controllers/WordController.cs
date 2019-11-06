using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Self.Core.Entities;
using Self.Core.Interfaces;

namespace Self.WebSpa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        #region Fields
        IWordRepository _wordRepository;
        #endregion

        #region CTOR
        public WordController(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }
        #endregion

        #region Actions
        #region Add Word
        public async Task<IActionResult> AddWord(Word newWord)
        {
            var result = await _wordRepository.AddAsync(newWord);

            if (result == null)
            {
                return BadRequest("Could not add!");
            }

            return Ok(newWord);
        }
        #endregion

        #region Get Word List
        [HttpGet]
        [Route("WordList")]
        public async Task<IActionResult> WordList()
        {
            IReadOnlyList<Word> wordList = await _wordRepository.GetListAllAsync();

            if (wordList == null)
            {
                return BadRequest("Could not get words");
            }

            return Ok(wordList);
        }
        #endregion

        #region Update Word
        public async Task<IActionResult> UpdateWord(Word updatedWord)
        {
            var result = await _wordRepository.UpdateAsync(updatedWord);

            if (!result)
            {
                return BadRequest("Could not update word.");
            }

            return Ok(updatedWord);
        }
        #endregion

        #region Delete Word
        public async Task<IActionResult> DeleteWord(int wordId)
        {
            Word deletedWord = await _wordRepository.GetByIdAsync(wordId);

            var result = await _wordRepository.DeleteAsync(deletedWord);

            if (!result)
            {
                return BadRequest("Could not delete word.");
            }

            return Ok();
        } 
        #endregion
        #endregion
    }
}