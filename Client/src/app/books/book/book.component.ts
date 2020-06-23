import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/shared/book.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { Book, IRequestResult, Category } from 'src/app/shared/category.model';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  constructor(public bookService: BookService, private notification: ToastrService) { }

  categories: Category[];

  ngOnInit(): void {
    this.resetForm();
    this.bookService.getCategories().subscribe((res : IRequestResult<Category[]>) =>{
      debugger
      this.categories = res.result;  
    });
  }


  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();

    this.bookService.bookForm = {
      nombre : '',
      author: null,
      category:0,
      identificador:null,
      isbn:''
    }
  }
  
  onSubmit(form: NgForm) {
    debugger
    if (form.value.identificador == null) {
      form.value.identificador = 0;
      form.value.author = parseInt(form.value.author);
      this.insertBook(form);
    }
    else {
      this.updateBook(form);
    }
  }

  insertBook(form: NgForm) {

    this.bookService.postBook(form.value).subscribe((res: IRequestResult<Book>) => {
      if (res.isSuccesfull) {
        this.notification.success('Creado Exitosamente', ' Libro creado');
        this.resetForm(form);
        this.bookService.reloadBookList();
      }
      else {
        this.notification.error(res.Messges, 'error al intentar Guardar el registo');
      }
    });

  }

  updateBook(form: NgForm) {
    this.bookService.putBook(form.value).subscribe((res: IRequestResult<Book>) => {

      if (res.isSuccesfull) {

        this.notification.success('Actualizado Exitosamente', 'Libro Actualizado');
        this.resetForm(form);
        this.bookService.reloadBookList();

      }
      else {
        this.notification.error(res.Messges, 'error al intentar Actualizar el registo');
      }
    })
  }


}
