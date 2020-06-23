import { Injectable } from '@angular/core';
import { Book, IRequestResult, Category, BookModel } from './category.model';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  categories: Category[];
  bookForm: Book;
  bookList : Book[];
  bookSearch: BookModel;

  readonly rootUrl = "http://localhost:59894/api";

  constructor(private http : HttpClient , private notification : ToastrService) {}

  postBook(bookForm: Book) {
    return this.http.post(this.rootUrl +'/Book/Create',bookForm);
  }

  reloadBookList(){
    this.http.get(this.rootUrl+'/Book/List').toPromise().then((res : IRequestResult<Book[]>)  => {
      if (res.isSuccesfull) {
        debugger
        this.bookList = res.result;
      }
      else
      {
        this.notification.error(res.Messges,'Ocurrio Un error al Obtener los datos');
      }
    });
  }

  
  putBook(bookForm: Book){
    return this.http.put(this.rootUrl+'/Book/Update',bookForm);
  }

  deleteBook(id: number){
    return this.http.delete(this.rootUrl+'/Book/Delete?id='+id);
  }

  getCategories(){
    return this.http.get(this.rootUrl+'/Category/List');
  }

  searchBook(url: string){
    return this.http.get(this.rootUrl+ '/Book/FindFilter?'+url);
  }
  
  getAuthor(){
    return this.http.get(this.rootUrl+'/Author/List');
  }

}
