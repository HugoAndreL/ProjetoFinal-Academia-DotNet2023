import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { faRightToBracket, faXmark } from '@fortawesome/free-solid-svg-icons';

import { LoginService } from '../../services/login.service';
import { Login } from '../../models/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  login = {} as Login;
  frmLogin!: FormGroup;

  icEntrar = faRightToBracket;
  icCancel = faXmark;

  constructor(private service: LoginService, private router: Router) {}

  ngOnInit() {
    const token = localStorage.getItem("token");
    this.service.ehExpiradoToken(token) ? this.router.navigate(['Login']) : this.router.navigate(['Home']);
    this.frmLogin = new FormGroup({
      id: new FormControl(''),
      username: new FormControl('',
        [Validators.required, Validators.maxLength(50)]),
      password: new FormControl('',
        [Validators.required, Validators.maxLength(35)]),
      aaId: new FormControl('',
        [Validators.required]) 
    });
  }

  Logar() {
    this.service.postLogin(this.login)
      .subscribe(log => {
        localStorage.setItem("token", log.token);
        alert('Login efetuado com sucesso! Bem vindo(a): ' + log.username);
        this.router.navigate(['Home']);
      });
  }
}