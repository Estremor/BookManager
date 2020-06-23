import { Component, OnInit } from '@angular/core';
import { AuthorService } from 'src/app/shared/author.service';
import { ToastrService } from 'ngx-toastr';
import { Author, IRequestResult } from 'src/app/shared/category.model';

@Component({
  selector: 'app-author-list',
  templateUrl: './author-list.component.html',
  styleUrls: ['./author-list.component.css']
})
export class AuthorListComponent implements OnInit {

  constructor(public authorService: AuthorService, private notification: ToastrService) { }

  ngOnInit(): void {
    this.authorService.reloadAuthorList();
  }

  selectAuthor(author: Author) {
    this.authorService.authorForm = Object.assign({}, author);
  }

  onDelete(id: number) {
    this.deleteAuthors(id);
  }


  deleteAuthors(id: number) {
    if (confirm('seguro desea Eliminar el Registro')) 
    {
      return this.authorService.deleteAuthor(id).subscribe((res: IRequestResult<Author>) => {
  
        if (res.isSuccesfull) {

          this.notification.warning('Author', 'se elimino correctamente');
          this.authorService.reloadAuthorList();
        }
        else {

          this.notification.error('Author Error ', res.Messges);
        }
      });      
    }
  }



}
