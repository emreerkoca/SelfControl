import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { Word } from '../_models/word';
import { WordService } from '../_services/word.service';

@Component({
  selector: 'app-get-words',
  templateUrl: './get-words.component.html',
  styleUrls: ['./get-words.component.css']
})
export class GetWordsComponent implements OnInit {
  words: Observable<Word[]>;

  constructor(private wordService: WordService) { }

  ngOnInit() {
    this.getWords();
  }

  getWords() {
    this.words = this.wordService.getWords();
  }

}