using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Self.Core.Entities;
using Self.Core.Interfaces;

namespace Self.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        #region Fields
        IWordRepository _wordRepository;
        #endregion

        #region Ctor
        public WordController(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        } 
        #endregion


        [HttpPost]
        [Route("AddWord")]
        public ActionResult<Word> AddWord(Word newWord)
        {
            Word word = _wordRepository.Add(newWord);

            if(word == null)
            {
                return NotFound();
            }

            return word;
        }

        [HttpGet]
        [Route("GetWordList")]
        public IEnumerable<Word> GetWordList()
        {
            IEnumerable<Word> wordList = _wordRepository.GetList();
          
            return wordList;
        }
    }
}
