import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styles: [
  ]
})
export class CategoriesComponent implements OnInit {
  categories: Category[] | undefined;
  constructor(private categoryService: CategoryService) {

  }
  ngOnInit(): void {
    this.categoryService.GetCategories().subscribe(res => {
      if (res.body != undefined) {
        this.categories = res.body;
      }
    });
  }
}
