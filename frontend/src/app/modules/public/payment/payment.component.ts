import { Component, NgZone, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RECEIPT_ID } from 'src/app/app.constant';
import { environment } from 'src/app/environments/environment';
import { Cart } from 'src/app/models/cart';
import { Payment } from 'src/app/models/payment';
import { RazorPayOrder } from 'src/app/models/razorpayorder';
import { User } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth.service';
import { CartService } from 'src/app/services/cart.service';
import { PaymentService } from 'src/app/services/payment.service';

declare const Razorpay: any;
@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styles: [
  ]
})
export class PaymentComponent implements OnInit {
  RAZORPAY_OPTIONS = {
    "key": "",
    "amount": "",
    "currency": "",
    "name": "",
    "description": "",
    "image": "~/assets/images/logo.png",
    "order_id": "",
    "handler": (res: any) => {
      //console.log(res);
    },
    "prefill": {
      "name": "",
      "email": "",
      "contact": ""
    },
    "notes": {
      "address": "NA"
    },
    "theme": {
      "color": "#4285F4"
    }
  };
  cart: Cart | any;
  user: User | undefined;
  constructor(private cartService: CartService, private authService: AuthService, private paymentService: PaymentService, private router: Router, private zone: NgZone) {
    this.user = this.authService.user;
  }
  ngOnInit(): void {
     //append js
     const script = document.createElement('script');
     script.src = 'https://checkout.razorpay.com/v1/checkout.js';
     script.async = true;
     document.body.appendChild(script);

    this.cart = this.cartService.getCart();
    if (this.cart.items.length > 0) {
      const order: RazorPayOrder = new RazorPayOrder(this.cart.grandTotal, 'INR', 'NA');
      this.paymentService.CreateOrder(order).subscribe(res => {
        if (res.status == 200) {
          this.RAZORPAY_OPTIONS.order_id = res.body.orderId;
        }
      });
    }
  }
  payWithRazorPay() {
    if (this.user != undefined) {
      this.RAZORPAY_OPTIONS.name = this.user?.name;
      let items = "";
      for (let i = 0; i < this.cart.items.length; i++) {
        items += this.cart.items[i].name + ",";
      }

      this.RAZORPAY_OPTIONS.description = items;
      this.RAZORPAY_OPTIONS.key = environment.razorPay.key;
      this.RAZORPAY_OPTIONS.amount = this.cart.grandTotal.toString();
      this.RAZORPAY_OPTIONS.currency = 'INR';

      this.RAZORPAY_OPTIONS.prefill.name = this.user.name;
      this.RAZORPAY_OPTIONS.prefill.email = this.user.email;
      this.RAZORPAY_OPTIONS.prefill.contact = this.user.phoneNumber;
      this.RAZORPAY_OPTIONS.handler = this.razorPaySuccessHandler.bind(this);

      const razorPay = new Razorpay(this.RAZORPAY_OPTIONS);
      razorPay.open();
    }
  }
  razorPaySuccessHandler(res: any) {
    const payment = new Payment();

    payment.signature = res.razorpay_signature;
    payment.orderId = res.razorpay_order_id;
    payment.paymentId = res.razorpay_payment_id;

    payment.cartId = this.cart.id;
    payment.items = this.cart.items;
    payment.total = this.cart.total;
    payment.tax = this.cart.tax;
    payment.grandTotal = this.cart.grandTotal;
    payment.currency = this.RAZORPAY_OPTIONS.currency;

    payment.email = this.user?.email;
    payment.userId = this.user?.id;

    this.paymentService.SavePaymentDetails(payment).subscribe(res => {
      if (res.status == 200) {
        this.cartService.removeCart();
        localStorage.setItem(RECEIPT_ID, JSON.stringify(res.body));

        this.zone.run(() => this.router.navigate(['receipt']));
      }
    });
  }
}
