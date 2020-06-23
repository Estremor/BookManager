import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/shared/category.service';
import { Category, IRequestResult } from 'src/app/shared/category.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styles: [
  ]
})
export class CategoryListComponent implements OnInit {

  constructor(public service: CategoryService, private notification: ToastrService) { }

  ngOnInit(): void {
    this.service.reloadList();
  }

  selectCategory(category: Category) {
    this.service.formData = Object.assign({}, category);
  }

  onDelete(id: number) {
    this.deleteCategories(id);
  }

  deleteCategories(id: number) {
    if (confirm('seguro desea Eliminar el Registro')) 
    {
      console.log(id);
      return this.service.deleteCategory(id).subscribe((res: IRequestResult<Category>) => {
  
        if (res.isSuccesfull) {
          this.notification.warning('Category', 'se elimino correctamente');
          this.service.reloadList();
        }
        else {
          this.notification.error('Category Error ', res.Messges);
        }
      });      
    }
  }

}
