import { Injectable } from '@angular/core';
import { Cart } from '../models/cart';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { CartItem } from '../models/cartItem';
import { CART_ID } from '../app.constant';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cart: Cart;
  private httpHeaders: HttpHeaders;
  constructor(private httpClient: HttpClient) {
    this.cart = new Cart();
    this.httpHeaders = new HttpHeaders({ 'content-type': 'application/json' });
  }
  SaveCartToDB(cart: Cart): Observable<HttpResponse<any>> {
    return this.httpClient.post<HttpResponse<any>>(environment.apiAddress + "/cart/savecart", JSON.stringify(cart), { headers: this.httpHeaders, observe: 'response' });
  }

  addToCart(itemId: number, name: string, imageUrl: string, unitPrice: number, quantity: number): void {
    if (quantity != undefined) {
      const item = new CartItem(itemId, name, imageUrl, unitPrice, quantity);
      this.cart.items.push(item);

      this.calculateCart();
      //save into local storage
      this.saveCart();
    }
  }
  calculateCart(): void {
    let price = 0;
    for (let i = 0; i < this.cart.items.length; i++) {
      const item: CartItem = this.cart.items[i];
      this.cart.items[i].total = item.quantity * item.unitPrice;
      price = price + this.cart.items[i].total;
    }
    this.cart.total = price;
    this.cart.tax = Math.round((price * this.cart.taxRate) / 100);
    this.cart.grandTotal = this.cart.total + this.cart.tax;
  }
  saveCart(): void {
    localStorage.setItem(this.cart.id, JSON.stringify(this.cart.items));
  }
  getCart(): Cart {
    const data = localStorage.getItem(this.cart.id);
    if (data != undefined && data != null) {
      this.cart.items = JSON.parse(data);
      this.calculateCart();
    }
    return this.cart;
  }
  removeCart(): void {
    localStorage.removeItem(this.cart.id);
    localStorage.removeItem(CART_ID);
  }

  deleteItem(id: number): void {
    for (let i = 0; i < this.cart.items.length; i++) {
      const item = this.cart.items[i];
      if (item.itemId == id) {
        this.cart.items.splice(i, 1);
      }
    }
    this.calculateCart();
    this.saveCart();
  }
}
