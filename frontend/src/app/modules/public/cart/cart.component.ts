import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Cart } from 'src/app/models/cart';
import { User } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth.service';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styles: [
  ]
})
export class CartComponent {
  cart: Cart;
  user: User | undefined;
  constructor(private cartService: CartService, private authService: AuthService, private router: Router) {
    this.cart = this.cartService.getCart();
    this.user = this.authService.user;
  }
  DeleteItem(id: number) {
    if (confirm('Are you sure to delete?')) {
      this.cartService.deleteItem(id);
      this.cart=this.cartService.getCart();
    }
  }
  checkOut() {
    if (this.user != undefined) {
      this.cart.userId = this.user.id;
      //console.log(this.cart);
      this.cartService.SaveCartToDB(this.cart).subscribe(res => {
        if (res.status == 200 && res.body == true) {
          this.router.navigate(['payment']);
        }
      });
    }
    else {
      this.router.navigate(['login'], { queryParams: { returnUrl: '/cart' } });
    }
  }
}
