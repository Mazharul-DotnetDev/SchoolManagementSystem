import { Component, ViewChild, inject, viewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
//import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { AuthRequest } from '../../SecurityModels/auth-request';
import { AuthService } from '../../SecurityModels/auth.service';
//import { AuthRequest } from '../auth-request';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
  @ViewChild('loginForm') loginForm!: NgForm;
  model!: AuthRequest;
  authService = inject(AuthService);
  router = inject(Router);
  constructor() {
    this.model = new AuthRequest();
  }
  login(event: Event) {

    if (this.loginForm.invalid) {
      this.loginForm.form.markAllAsTouched();
      return;
    }



    event.preventDefault();

    console.log(`Login: ${this.model.email} / ${this.model.password}`);

    this.authService
      .login(this.model)
      .subscribe(() => {
        alert('Login success!');
        this.router.navigate(['/']);
      });
  }
}
