import { Component, inject } from '@angular/core';
import { AuthService } from './Authentication/SecurityModels/auth.service';
import { AuthResponse } from './Authentication/SecurityModels/auth-response';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
  
})
export class AppComponent {
  title = 'NG.ClientsSchoolAPI';
  private authService = inject(AuthService);
  user!: AuthResponse;
  public login!: boolean;


  ngOnInit() {

    this.login = this.authService.isLoggedIn();
    this.user = this.authService.getCurrentAuthUser();
   
  }

  logout() {
    this.authService.logout();
  }

  refreshToken() {
    this.authService.refreshToken()?.subscribe(() => { });
  }


}
