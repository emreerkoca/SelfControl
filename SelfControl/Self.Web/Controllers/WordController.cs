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

        // GET: /<controller>/
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

            var result = _wordRepository.Add(newWord);

            if (result == null)
            {
                return BadRequest("Could not add word.");
            }

            return RedirectToAction("WordList");
        }

        public IActionResult WordList()
        {
            IEnumerable<Word> wordList = _wordRepository.GetList();

            return View(wordList);
        }


        public IActionResult JumpWord()
        {
            Word word = _wordRepository.GetRandomWord();

            return PartialView("JumpWordPartial",word);
        }
    }
}
