import { Component } from '@angular/core';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from '../../core/services/auth.services';
import { LoginRequest } from '../../models/login-request';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {}

  loginForm = this.fb.group({
    login: ['', Validators.required],
    senha: ['', Validators.required]
  });

  login(): void {

    if (this.loginForm.invalid) {
      return;
    }

    const request: LoginRequest = {
      login: this.loginForm.value.login ?? '',
      senha: this.loginForm.value.senha ?? ''
    };

    this.authService.login(request).subscribe({

      next: (response) => {

        this.authService.salvarToken(response.token);

        alert(response.mensagem);

        this.router.navigate(['/home']);

      },

      error: (erro) => {
        
        // console.log('Erro completo:', erro);
        // console.log('Status:', erro.status);
        // console.log('URL:', erro.url);
        // console.log('Corpo:', erro.error);
        console.error(erro);

        alert('Usuário ou senha inválidos.');
      }

    });

  }

}