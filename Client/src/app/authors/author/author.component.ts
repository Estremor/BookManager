import { Component, OnInit } from '@angular/core';
import { AuthorService } from 'src/app/shared/author.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { Author, IRequestResult } from 'src/app/shared/category.model';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent implements OnInit {

  constructor(public authorService: AuthorService, private notification: ToastrService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();

    this.authorService.authorForm = {
      nombre :'',
      apellido:'',
      fechaNacimiento: null,
      identificador: null
    }
  }

  onSubmit(form: NgForm) {
    
    if (form.value.identificador == null) {
      form.value.identificador = 0;
      this.insertAuthor(form);
    }
    else {
      this.updateAuthor(form);
    }
  }

  insertAuthor(form: NgForm) {

    this.authorService.postAuthor(form.value).subscribe((res: IRequestResult<Author>) => {
      if (res.isSuccesfull) {
        this.notification.success('Creado Exitosamente', ' Author creado');
        this.resetForm(form);
        this.authorService.reloadAuthorList();
      }
      else {
        this.notification.error(res.Messges, 'error al intentar Guardar el registo');
      }
    });

  }

  updateAuthor(form: NgForm) {
    this.authorService.PutAuthor(form.value).subscribe((res: IRequestResult<Author>) => {
      if (res.isSuccesfull) {
        this.notification.success('Actualizado Exitosamente', ' Author Actualizado');
        this.resetForm(form);
        this.authorService.reloadAuthorList();
      }
      else {
        this.notification.error(res.Messges, 'error al intentar Actualizar el registo');
      }
    })
  }

}
