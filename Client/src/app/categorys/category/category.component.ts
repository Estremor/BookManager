import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/shared/category.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Category, IRequestResult } from 'src/app/shared/category.model';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styles: [
  ]
})

export class CategoryComponent implements OnInit {

  constructor(public service: CategoryService, private notification: ToastrService) { }

  ngOnInit(): void {
    this.resetForm()
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();

    this.service.formData = {
      descripcion: '',
      nombre: '',
      identificador: null
    }
  }

  onSubmit(form: NgForm) {
    if (form.value.identificador == null) {
      form.value.identificador = 0;
      this.insertCategory(form);
    }
    else {
      this.updateCategory(form);
    }
  }

  insertCategory(form: NgForm) {

    this.service.postCategory(form.value).subscribe((res: IRequestResult<Category>) => {
      if (res.isSuccesfull) {
        this.notification.success('Creado Exitosamente', ' Categoria Creada');
        this.resetForm(form);
        this.service.reloadList();
      }
      else {
        this.notification.error(res.Messges, 'error al intentar Guardar el registo');
      }
    });

  }

  updateCategory(form: NgForm) {
    this.service.PutCategory(form.value).subscribe((res: IRequestResult<Category>) => {
      if (res.isSuccesfull) {
        this.notification.success('Actualizado Exitosamente', ' Categoria Actualizada');
        this.resetForm(form);
        this.service.reloadList();
      }
      else {
        this.notification.error(res.Messges, 'error al intentar Actualizar el registo');
      }
    })
  }

}
