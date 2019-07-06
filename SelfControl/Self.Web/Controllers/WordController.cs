﻿using System;
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
        public async Task<IActionResult> AddWord(Word newWord)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var result = await _wordRepository.AddAsync(newWord);

            if (result == null)
            {
                return BadRequest("Could not add word.");
            }

            return RedirectToAction("WordList");
        }

        public async Task<IActionResult> WordList()
        {
            IReadOnlyList<Word> wordList = await _wordRepository.GetListAsync();

            return View(wordList);
        }

        #region Update Word
        [HttpGet]
        public async Task<IActionResult> UpdateWord(int wordId)
        {
            Word word = new Word();
            word = await _wordRepository.GetByIdAsync(wordId);

            return View(word);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWord(Word updatedWord)
        {
            var result = await _wordRepository.UpdateAsync(updatedWord);

            if (!result)
            {
                return BadRequest("Could not update word.");
            }

            return RedirectToAction("WordList");
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

            return RedirectToAction("WordList");

        }
        #endregion

        public async Task<IActionResult> GetRandomWord()
        {
            Task<Word> word = _wordRepository.GetRandomWordAsync();

            return PartialView("JumpWordPartial",word);
        }
    }
}
