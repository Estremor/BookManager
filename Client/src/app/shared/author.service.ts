import { Injectable } from '@angular/core';
import { Author,IRequestResult } from './category.model';
import { HttpClient } from "@angular/common/http"
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

  authorForm: Author;
  authorList : Author[];

  readonly rootUrl = "http://localhost:59894/api";

  constructor(private http : HttpClient , private notification : ToastrService) {}

  postAuthor(authorForm: Author) {
    return this.http.post(this.rootUrl +'/Author/Create',authorForm);
  }

  reloadAuthorList(){
    this.http.get(this.rootUrl+'/Author/List').toPromise().then((res : IRequestResult<Author[]>)  => {
      if (res.isSuccesfull) {
        debugger
        this.authorList = res.result;
      }
      else
      {
        this.notification.error(res.Messges,'Ocurrio Un error al Obtener los datos');
      }
    });
  }

  getAuthor(){
    return this.http.get(this.rootUrl+'/Author/List');
  }

  PutAuthor(authorForm: Author){
    return this.http.put(this.rootUrl+'/Author/Update',authorForm);
  }

  deleteAuthor(id: number){
    return this.http.delete(this.rootUrl+'/Author/Delete?id='+id);
  }

}
