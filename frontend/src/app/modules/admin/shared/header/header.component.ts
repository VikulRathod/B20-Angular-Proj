import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styles: [
  ]
})
export class HeaderComponent {
  user: User | undefined;
  constructor(private authService: AuthService, private router: Router) {
    this.user = this.authService.user;
  }
  SignOut() {
    this.authService.RemoveAuthUser();
    this.user = undefined;
    return this.router.navigate(['/login']);
  }
}
