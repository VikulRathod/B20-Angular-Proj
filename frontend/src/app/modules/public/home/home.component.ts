import { Component, OnInit } from '@angular/core';
import { Catalog } from 'src/app/models/catalog';
import { CartService } from 'src/app/services/cart.service';
import { CatalogService } from 'src/app/services/catalog.service';
declare const $: any;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: [
  ]
})
export class HomeComponent implements OnInit {
  catalogList: Catalog[] | undefined;
  message: string | undefined;
  constructor(private catalogService: CatalogService, private cartService: CartService) {

  }
  ngOnInit(): void {
    this.catalogService.GetCatalog().subscribe(res => {
      if (res.body != undefined) {
        this.catalogList = res.body;
      }
    });
  }

  AddToCart(id: number, name: string, unitPrice: number, quantity: number, image: string) {
    this.cartService.addToCart(id, name, image, unitPrice, quantity);
    this.message = `<strong>${name}</strong> Added to <a href="/cart">Cart</a> successfully!`;
    $('#toastCart').toast('show');
    setTimeout(() => {
      $('#toastCart').toast('hide');
    }, 4000);
  }
}
