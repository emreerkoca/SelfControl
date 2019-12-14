import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { GetWordsComponent } from './get-words/get-words.component';
import { AddEditWordComponent } from './add-edit-word/add-edit-word.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    GetWordsComponent,
    AddEditWordComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'add-word', component: AddEditWordComponent },
      { path: 'edit-word/:id', component: AddEditWordComponent },
      { path: 'get-words', component: GetWordsComponent },
      { path: '**', redirectTo: '/' } // for invalid paths
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
