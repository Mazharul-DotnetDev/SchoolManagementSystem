import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../../SecurityModels/auth.service';
import { RegistrationRequest } from '../../SecurityModels/RegistrationRequest';
import { Router } from '@angular/router';
import { AuthRegRequest } from '../../SecurityModels/AuthRegRequest';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {
  @ViewChild('registrationForm') registrationForm!: NgForm;
  model = new AuthRegRequest();

  constructor(private authService: AuthService, private router: Router) {}

  register() {
    if (this.registrationForm.invalid) {
      this.registrationForm.form.markAllAsTouched();
      return;
    }
    this.authService.register(this.model).subscribe(() => {
      alert('Registration successful!');
      // Optionally, navigate to another page after successful registration
      this.router.navigate(['/login']);
    });
  }
}
