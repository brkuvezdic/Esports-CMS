import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login-register-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './login-register-page.html',
  styleUrl: './login-register-page.css',
})
export class LoginRegisterPage {
  isLoginMode = true;

  toggleMode() {
    this.isLoginMode = !this.isLoginMode;
  }
}
