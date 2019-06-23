using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Self.Core.Entities;
using Self.Core.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Self.Web.Controllers
{
    public class WordController : Controller
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddWord()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddWord(Word newWord)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var result = _wordRepository.AddAsync(newWord);

            if (result == null)
            {
                return BadRequest("Could not add word.");
            }

            return RedirectToAction("WordList");
        }

        public async Task<IActionResult> WordList()
        {
            Task<IReadOnlyList<Word>> wordList = _wordRepository.GetListAsync();

            return View(wordList);
        }


        public async Task<IActionResult> GetRandomWord()
        {
            Task<Word> word = _wordRepository.GetRandomWordAsync();

            return PartialView("JumpWordPartial",word);
        }
    }
}
