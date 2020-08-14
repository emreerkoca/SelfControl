using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Self.Core.DTOs;
using Self.Core.Entities;
using Self.Core.Interfaces;
using Self.Core.Paging;
using Self.Service;
using Self.WebSpaReact.Exceptions;

namespace Self.WebSpaReact.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WordController : ControllerBase
    {
        #region Fields
        private readonly ILogger<WordController> _logger;
        IWordService _wordService;
        #endregion

        #region CTOR
        public WordController(IWordService wordService, ILogger<WordController> logger)
        {
            _wordService = wordService;
            _logger = logger;

            _logger.LogDebug(1, "NLog injected to WordController");
        }
        #endregion

        #region Actions
        #region GetWord
        [AllowAnonymous]
        [HttpGet("get-word/{wordId}")]
        public async Task<IActionResult> GetWordById(int wordId)
        {
            Word word = await _wordService.GetWordById(wordId);

            if (word == null)
            {
                throw new NotFoundException($"Word with Id {wordId} not found!");
            }

            _logger.LogInformation("GetWord ok!");

            return new OkObjectResult(word);
        }
        #endregion

        #region Add Word
        [HttpPost("add-word")]
        public async Task<IActionResult> AddWord([FromBody] Word newWord)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Your data is not valid");
            }

            var result = await _wordService.AddWord(newWord);

            if (result == null)
            {
                throw new Exception("Could not add word!");
            }

            return Ok(newWord);
        }
        #endregion

        #region Get Word List
        [HttpGet("get-words")]
        public async Task<IActionResult> GetWords(int userId, int isUpdated)
        {
            IReadOnlyList<Word> wordList = await _wordService.GetWords(userId, isUpdated);

            if (wordList == null)
            {
                throw new NotFoundException("Could not get words");
            }

            return Ok(wordList);
        }

        [HttpGet("get-words-by-range")]
        public IActionResult GetWordsByRange([FromQuery] PagingParameters pagingParameters, int userId, int isUpdated)
        {
            ItemListDTO<Word> wordListDTO = _wordService.GetWordsByRange(userId, isUpdated, pagingParameters);

            if (wordListDTO == null)
            {
                throw new Exception("Could not get words");
            }

            return Ok(wordListDTO);
        }
        #endregion

        #region Update Word   
        [HttpPut("update-word/{wordId}")]
        public async Task<IActionResult> UpdateWord([FromRoute] int wordId, [FromBody] Word updatedWord)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Your data is not valid");
            }

            if (wordId != updatedWord.Id)
            {
                throw new Exception("Something went wrong! We' re working on it!");
            }

            await _wordService.UpdateWord(updatedWord);

            return Ok(updatedWord);
        }
        #endregion

        #region Delete Word
        [HttpDelete("delete-word/{wordId}")]
        public async Task<IActionResult> DeleteWord(int wordId)
        {
            Word deletedWord = await _wordService.GetWordById(wordId);

            if (deletedWord == null)
            {
                throw new NotFoundException("Could not find word. You can check your words again!");
            }

            await _wordService.DeleteWord(deletedWord);

            return Ok("1");
        }
        #endregion
        #endregion
    }
}
