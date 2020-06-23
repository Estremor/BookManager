import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from "@angular/forms";
import { HttpClientModule} from "@angular/common/http";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ToastrModule } from "ngx-toastr";

import { AppComponent } from './app.component';
import { CategorysComponent } from './categorys/categorys.component';
import { CategoryComponent } from './categorys/category/category.component';
import { CategoryListComponent } from './categorys/category-list/category-list.component';
import { CategoryService } from './shared/category.service';
import { AuthorsComponent } from './authors/authors.component';
import { AuthorComponent } from './authors/author/author.component';
import { AuthorListComponent } from './authors/author-list/author-list.component';
import { BooksComponent } from './books/books.component';
import { BookComponent } from './books/book/book.component';
import { BookListComponent } from './books/book-list/book-list.component';
import { BookSearchComponent } from './book-search/book-search.component';

@NgModule({
  declarations: [
    AppComponent,
    CategorysComponent,
    CategoryComponent,
    CategoryListComponent,
    AuthorsComponent,
    AuthorComponent,
    AuthorListComponent,
    BooksComponent,
    BookComponent,
    BookListComponent,
    BookSearchComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [CategoryService],
  bootstrap: [AppComponent]
})
export class AppModule { }
