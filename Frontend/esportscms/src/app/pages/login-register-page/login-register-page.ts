import { Component } from '@angular/core';

import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-login-register-page',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login-register-page.html',
  styleUrl: './login-register-page.css',
})
export class LoginRegisterPage {

  isLoginMode = true;
  form: FormGroup;
  message = '';

  constructor(private fb: FormBuilder, private auth: AuthService) {
    this.form = this.fb.group({
      username: [''],
      password: ['']
    });
  }

  toggleMode() {
    this.isLoginMode = !this.isLoginMode;
    this.message = '';
  }

  submit() {
    const request = this.form.value;

    if (this.isLoginMode) {
      this.auth.login(request).subscribe({
        next: (res) => {
          this.message = 'Logged in!';
          localStorage.setItem('access_token', res.accessToken);
          localStorage.setItem('refresh_token', res.refreshToken);
        },
        error: (err) => {
          this.message = err.error || 'Invalid login.';
        }
      });
    } else {
      this.auth.register(request).subscribe({
        next: () => {
          this.message = 'Account created! You can now log in.';
          this.isLoginMode = true;
        },
        error: (err) => {
          this.message = err.error || 'Registration failed.';
        }
      });
    }
  }
}
