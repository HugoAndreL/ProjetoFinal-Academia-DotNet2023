import { Component, Output } from '@angular/core';
import { Login } from '../../models/login';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import { faRightToBracket, faXmark } from '@fortawesome/free-solid-svg-icons';

import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  login = {} as Login;

  icEntrar = faRightToBracket;
  icCancel = faXmark;

  constructor(private service: LoginService, private router: Router, private http: HttpClient) {}

  ngOnInit() {
    const token = localStorage.getItem("token")
    if (this.service.ehExpirado(token))
      this.router.navigate([''])
    else
      this.router.navigate(['/Home']);
  }

  Logar() {
    this.service.postLogin(this.login)
      .subscribe(log => {
        localStorage.setItem("token", log.token);
        alert('Login efetuado com sucesso! Bem vindo(a): ' + this.login.username);
        this.router.navigate(['/Home']);
      });
  }
}