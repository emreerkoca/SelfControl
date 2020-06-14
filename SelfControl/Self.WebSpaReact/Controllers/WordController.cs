using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Self.Core.Entities;
using Self.Core.Interfaces;
using Self.Service;

namespace Self.WebSpaReact.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WordController : ControllerBase
    {
        #region Fields
        IWordService _wordService;
        #endregion

        #region CTOR
        public WordController(IWordService wordService)
        {
            _wordService = wordService;
        }
        #endregion

        #region Actions
        #region GetWord
        [HttpGet("get-word/{wordId}")]
        public async Task<IActionResult> GetWordById(int wordId)
        {
            Word word = await _wordService.GetWordById(wordId);

            return Ok(word);
        }
        #endregion

        #region Add Word
        [HttpPost("add-word")]
        public async Task<IActionResult> AddWord([FromBody] Word newWord)
        {
            var result = _wordService.AddWord(newWord);

            if (result == null)
            {
                return BadRequest("Could not add!");
            }

            return Ok(newWord);
        }
        #endregion

        #region Get Word List
        [HttpGet("get-words")]
        public async Task<IActionResult> GetWords(int userId)
        {
            IReadOnlyList<Word> wordList = await _wordService.GetWords(userId);

            if (wordList == null)
            {
                return BadRequest("Could not get words");
            }

            return Ok(wordList);
        }
        #endregion

        #region Update Word   
        [HttpPut("update-word/{wordId}")]
        public async Task<IActionResult> UpdateWord([FromRoute] int wordId, [FromBody] Word updatedWord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (wordId != updatedWord.Id)
            {
                return BadRequest();
            }

            _wordService.UpdateWord(updatedWord);

            return Ok(updatedWord);
        }
        #endregion

        #region Delete Word
        [HttpDelete("delete-word/{wordId}")]
        public async Task<IActionResult> DeleteWord(int wordId)
        {
            Word deletedWord = await _wordService.GetWordById(wordId);

            await _wordService.DeleteWord(deletedWord);

            return Ok("1");
        }
        #endregion
        #endregion
    }
}
