import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/shared/book.service';
import { ToastrService } from 'ngx-toastr';
import { Book, IRequestResult } from 'src/app/shared/category.model';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {

  constructor(public bookService: BookService, private notification: ToastrService) { }

  ngOnInit(): void {
    this.bookService.reloadBookList();
  }

  selectBook(book: Book) {
    this.bookService.bookForm = Object.assign({}, book);
  }

  onDelete(id: number) {
    this.deleteBook(id);
  }

  deleteBook(id: number) {
    if (confirm('seguro desea Eliminar el Registro')) 
    {
      return this.bookService.deleteBook(id).subscribe((res: IRequestResult<Book>) => {
  
        if (res.isSuccesfull) {

          this.notification.warning('Libro', 'se elimino correctamente');
          this.bookService.reloadBookList();
        }
        else {

          this.notification.error('Libro Error ', res.Messges);
        }
      });      
    }
  }

}
