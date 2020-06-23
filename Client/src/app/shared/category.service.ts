import { Injectable } from '@angular/core';
import { Category, IRequestResult } from './category.model';
import { HttpClient } from "@angular/common/http"
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {

  formData: Category;
  list : Category[];
  readonly rootUrl = "http://localhost:59894/api";

  constructor(private http : HttpClient , private notification : ToastrService) {}

  postCategory(formData: Category) {
    return this.http.post(this.rootUrl +'/Category/Create',formData);

  }

  reloadList(){
    this.http.get(this.rootUrl+'/Category/List').toPromise().then((res : IRequestResult<Category[]>)  => {
      if (res.isSuccesfull) {
        debugger
        this.list = res.result;
      }
      else
      {
        this.notification.error(res.Messges,'Ocurrio Un error al Obtener los datos');
      }
    });
  }

  PutCategory(formData: Category){
    return this.http.put(this.rootUrl+'/Category/Update',formData);
  }

  deleteCategory(id: number){
    return this.http.delete(this.rootUrl+'/Category/Delete?id='+id);
  }

}
