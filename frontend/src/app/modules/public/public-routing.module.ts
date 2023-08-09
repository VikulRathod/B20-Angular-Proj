import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './shared/layout.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { HomeComponent } from './home/home.component';
import { CartComponent } from './cart/cart.component';
import { PaymentComponent } from './payment/payment.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { UnauthorizeComponent } from './unauthorize/unauthorize.component';
import { ReceiptComponent } from './receipt/receipt.component';

const routes: Routes = [
    {
        path: '', component: LayoutComponent, children: [
            { path: '', component: HomeComponent },
            { path: 'login', component: LoginComponent },
            { path: 'signup', component: SignupComponent },
            { path: 'cart', component: CartComponent },
            { path: 'payment', component: PaymentComponent },
            { path: 'receipt', component: ReceiptComponent },
            { path: 'unauthorize', component: UnauthorizeComponent },
            { path: 'notfound', component: NotfoundComponent },
            { path: '**', redirectTo: '/notfound' }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PublicRoutingModule { }
