import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

import { Word } from '../_models/word';


@Injectable({
  providedIn: 'root'
})
export class WordService {
  wordApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(private httpClient: HttpClient) {
    this.wordApiUrl = environment.appUrl + 'api/Word/';
  }

  getWordById(wordId: number): Observable<Word> {
    return this.httpClient.get<Word>(this.wordApiUrl + 'GetWord/' + wordId)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  getWords(): Observable<Word[]> {
    return this.httpClient.get<Word[]>(this.wordApiUrl + 'WordList')
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  addWord(word): Observable<Word> {
    return this.httpClient.post<Word>
      (this.wordApiUrl + 'AddWord', JSON.stringify(word), this.httpOptions)
        .pipe(
          retry(1),
          catchError(this.errorHandler)
        );
  }

  updateWord(word: Word) {
    return this.httpClient.put<Word>(this.wordApiUrl + 'UpdateWord', JSON.stringify(word))
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  deleteWord(wordId: number) {
    return this.httpClient.delete<Word>(this.wordApiUrl + 'DeleteWord?wordId=' + wordId)
        .pipe(
          retry(1),
          catchError(this.errorHandler)
        );
  }

  errorHandler(event) {
    let errorMessage = '';
    if (event.error instanceof ErrorEvent) {
      errorMessage = event.error.message;
    } else {
      errorMessage = `Error Code: ${event.status}\nMessage: ${event.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
