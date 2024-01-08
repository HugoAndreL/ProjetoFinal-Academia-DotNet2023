import { Component } from '@angular/core';
import { Funcionalidade } from '../../models/funcionalidade';
import { Usuario } from '../../models/usuario';
import { faDoorClosed } from '@fortawesome/free-solid-svg-icons';
import { LoginService } from '../../services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  permissoes: Funcionalidade[] = [];
  user = {} as Usuario;

  icLogout = faDoorClosed;

  constructor(private service: LoginService, private router: Router) {}

  ngOnInit() {
    this.service.getUserByToken()
    .subscribe((user) => {
      this.user = user;
    });
    this.service.getFuncsbyToken()
    .subscribe((funcs: Funcionalidade[]) => {
      this.permissoes = funcs;
    });
  }

  Logout() {
    this.service.pacthLogin()
      .subscribe(() => {
        localStorage.removeItem("token");
        this.router.navigate(['Login']);
      });
  }
}