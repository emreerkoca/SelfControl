import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

import { Word } from '../_models/word';


@Injectable({
  providedIn: 'root'
})
export class WordService {
  wordApiUrl: string;
  additionalUrlPart: string;

  constructor(private httpClient: HttpClient) {
    this.wordApiUrl = environment.appUrl;
    this.additionalUrlPart = 'api/Word/WordList/';
  }

  getWords(): Observable<Word[]> {
    return this.httpClient.get<Word[]>(this.wordApiUrl + this.additionalUrlPart)
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
