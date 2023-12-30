import { Component } from '@angular/core';
import { Login } from '../../models/login';
import { faRightToBracket, faXmark } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  login = {} as Login;

  icEntrar = faRightToBracket;
  icCancel = faXmark;

  addLogin() {
    throw new Error('Method not implemented.');
  }
}
