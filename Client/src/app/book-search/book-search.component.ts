import { Component, OnInit } from '@angular/core';
import { BookService } from '../shared/book.service';
import { ToastrService } from 'ngx-toastr';
import { Category, IRequestResult, Author, BookResult } from '../shared/category.model';
import { NgForm } from '@angular/forms';
import { AuthorService } from '../shared/author.service';
@Component({
  selector: 'app-book-search',
  templateUrl: './book-search.component.html',
  styleUrls: ['./book-search.component.css']
})
export class BookSearchComponent implements OnInit {

  categories: Category[];
  authors: Author[];
  results: BookResult[];

  constructor(public bookService: BookService, private authorService: AuthorService, private notification: ToastrService) { }

  ngOnInit(): void {
    this.resetForm();
    this.bookService.getCategories().subscribe((res: IRequestResult<Category[]>) => {
      this.categories = res.result;
    });

    this.authorService.getAuthor().subscribe((res: IRequestResult<Author[]>) => {
      this.authors = res.result;
    });

  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();

    this.bookService.bookSearch = {
      autor: "0",
      categori: "0",
      name: ""
    }
  }

  onSubmit(form: NgForm) {

    if (!this.validateForm(form)) {
      this.notification.warning('Busqueda ', ' Seleccione Un criterio de busqueda');
      return;
    }

    let url = this.createUrl(form);
    this.bookService.searchBook(url).subscribe((res : IRequestResult<BookResult[]>) => {
      if (res.result.length == 0) {
        this.notification.warning('Busqueda ', ' No se encontraron resultados');
      }
      else{
        this.notification.success('Busqueda ', 'se encontraron '+ res.result.length+' resultados');
      }
      this.results = res.result;
    });
  }

  validateForm(form: NgForm){
    debugger
    if (form.value.name.trim() =="" && form.value.categori =="0" && form.value.autor =="0") {
      return false;
    }
    return true;
  }

  createUrl(form: NgForm): string{
    let url ="";
debugger
    if (form.value.name.trim() != "") {
      url += "name="+form.value.name;
    }
    if (form.value.categori != "0") 
    {
      url.length > 0 ? 
      url += "&categori="+form.value.categori 
      : url += "categori="+form.value.categori;
    }
    if (form.value.autor != "0") 
    {
      url.length > 0 ? 
      url += "&autor="+form.value.autor 
      : url += "autor="+form.value.autor;
    }
    return url;
  }

}
