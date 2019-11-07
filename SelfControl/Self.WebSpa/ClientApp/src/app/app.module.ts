import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AddWordComponent } from './add-word/add-word.component';
import { UpdateWordComponent } from './update-word/update-word.component';
import { GetWordsComponent } from './get-words/get-words.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AddWordComponent,
    UpdateWordComponent,
    GetWordsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'add-word', component: AddWordComponent },
      { path: 'update-word/:id', component: UpdateWordComponent },
      { path: 'get-words', component: GetWordsComponent },
      { path: '**', redirectTo: '/' } // for invalid paths
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
