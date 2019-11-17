import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Word } from '../_models/word';
import { WordService } from '../_services/word.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-edit-word',
  templateUrl: './add-edit-word.component.html',
  styleUrls: ['./add-edit-word.component.css']
})
export class AddEditWordComponent implements OnInit {
  form: FormGroup;
  actionType: string;
  formOriginalWord: string;
  formTranslatedWord: string;
  formSentence: string;
  wordId: number;
  errorMessage: any;
  existingWord: Word;

  constructor(private wordService: WordService, private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute, private router: Router) { 
      const idParameter = 'id';
      this.actionType = 'Add';
      this.formOriginalWord = 'originalWord';
      this.formTranslatedWord = 'translatedWord';
      this.formSentence = 'sentence';

      if (this.activatedRoute.snapshot.params[idParameter]) {
        this.wordId = this.activatedRoute.snapshot.params[idParameter];
      }

      this.form = this.formBuilder.group(
        {
          wordId: 0,
          originalWord: ['', Validators.required],
          translatedWord: ['', Validators.required],
          sentence: ['', Validators.required]
        }
      );
    }

  ngOnInit() {
    if (this.wordId > 0) {
      this.actionType = 'Edit';
      this.wordService.getWordById(this.wordId)
        .subscribe(data => (
          this.existingWord = data,
          this.form.controls[this.formOriginalWord].setValue(data.originalWord),
          this.form.controls[this.formTranslatedWord].setValue(data.translatedWord),
          this.form.controls[this.formSentence].setValue(data.sentence)
        ));
    }
  }

  addOrUpdateWord() {
    if (!this.form.valid) {
      return;
    }

    if (this.actionType === 'Add') {
      let word: Word = {
        id: 1,
        originalWord: this.form.get(this.formOriginalWord).value,
        translatedWord: this.form.get(this.formTranslatedWord).value,
        sentence: this.form.get(this.formSentence).value,
        ownerId: 'test@sampledomain.com',
        viewCount: 0,
      };

      this.wordService.addWord(word)
        .subscribe((data) => {
          this.router.navigate(['/get-words']);
        });
    }

    if (this.actionType === 'Edit') {
      let word: Word = {
        id: this.existingWord.id,
        originalWord: this.form.get(this.formOriginalWord).value,
        translatedWord: this.form.get(this.formTranslatedWord).value,
        sentence: this.form.get(this.formSentence).value,
        ownerId: this.existingWord.ownerId,
        viewCount: this.existingWord.viewCount,

      };

      this.wordService.updateWord(word)
        .subscribe((data) => {
          this.router.navigate(['/get-words']);
        });
    }
  }

  cancel() {
    this.router.navigate(['/']);
  }

  get originalWord() { return this.form.get(this.formOriginalWord); }
  get translatedWord() { return this.form.get(this.formTranslatedWord); }
  get sentence() { return this.form.get(this.formSentence); }
}
