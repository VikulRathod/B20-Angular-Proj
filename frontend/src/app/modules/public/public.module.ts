import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { CartComponent } from './cart/cart.component';
import { PaymentComponent } from './payment/payment.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { LayoutComponent } from './shared/layout.component';
import { HeaderComponent } from './shared/header/header.component';
import { FooterComponent } from './shared/footer/footer.component';
import { PublicRoutingModule } from './public-routing.module';
import { UnauthorizeComponent } from './unauthorize/unauthorize.component';
import { ReceiptComponent } from './receipt/receipt.component';

@NgModule({
  declarations: [
    HomeComponent,
    LoginComponent,
    SignupComponent,
    CartComponent,
    PaymentComponent,
    NotfoundComponent,
    LayoutComponent,
    HeaderComponent,
    FooterComponent,
    UnauthorizeComponent,
    ReceiptComponent
  ],
  imports: [
    CommonModule,
    FormsModule, ReactiveFormsModule,
    PublicRoutingModule
  ]
})
export class PublicModule { }
