import { Component, inject } from '@angular/core';
import { AuthService } from '../../Authentication/SecurityModels/auth.service';
import { AuthResponse } from '../../Authentication/SecurityModels/auth-response';
import { CommonServices } from '../../Services/common.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  title = 'NG.ClientsSchoolAPI';
  private authService = inject(AuthService);
  user!: AuthResponse;
  public login!: boolean;
  constructor(private sidebarService: CommonServices) { }

  toggleSidebar() {
    // Check if the button click event is registered
    this.sidebarService.toggleSidebar();
    // Check if the visibility state is changing
  }
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
