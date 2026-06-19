import { Component, inject } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { LoginResponse} from '../../../core/models/auth/login-response.model'
import { AuthService } from '../../../core/services/auth.service';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  private readonly authService = inject(AuthService);

  probarLogin(): void {
  console.log('Botón presionado');

    this.authService.login({
      usuario: 'admin',
      password: 'adminalfonso'
    })
    .subscribe({
      next: (response: LoginResponse)  => {

        console.log('OK');
        console.log(response);

      },
      error: (error: HttpErrorResponse) => {

  console.log('STATUS', error.status);
  console.log('MESSAGE', error.message);
  console.log('ERROR', error.error);
        console.error(error);

      }
    });

  }
}

