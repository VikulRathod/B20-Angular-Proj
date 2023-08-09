import { Injectable } from '@angular/core';
import { CanActivate, Router} from '@angular/router';
import { AuthService } from './services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminAuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {

  }
  canActivate(): boolean {
    //authentication
    if (this.authService.user == undefined) {
      this.router.navigate(['login']);
      return true;
    }
    //authorization
    else if (this.authService.user.roles.find(r => r == 'Admin') == 'Admin') {
      return true;
    }
    else {
      this.router.navigate(['unauthorize']);
      return true;
    }
  }
}
