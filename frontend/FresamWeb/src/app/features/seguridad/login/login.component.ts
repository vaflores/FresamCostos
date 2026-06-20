import { Component, inject } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms'
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

import { LoginResponse} from '../../../core/models/auth/login-response.model'
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    ReactiveFormsModule,

    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatProgressSpinnerModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})

export class LoginComponent {
  private readonly authService = inject(AuthService);
  private readonly fb = inject(FormBuilder);

  loginForm: FormGroup = this.fb.group({
    usuario: [
      '',
      Validators.required
    ],
    password: [
      '',
      Validators.required
    ]
  });

  isLoading = false;
  errorMessage = '';

  probarLogin(): void {
  console.log('Botón presionado');

    if (this.loginForm.invalid) {
      return;
    }

  this.errorMessage = '';
  this.isLoading = true;

  this.authService
    .login(this.loginForm.getRawValue())
    .subscribe({
      next: (response: LoginResponse) => {

        this.isLoading = false;

        alert('Login exitoso');

        console.log(response);

      },
      error: (error: HttpErrorResponse) => {

        this.isLoading = false;

        this.errorMessage =
          'Usuario o contraseña incorrectos.';

        console.error(error);

      }
    });

  }
}

