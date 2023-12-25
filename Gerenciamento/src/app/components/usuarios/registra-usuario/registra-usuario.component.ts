import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { faPlus, faXmark } from '@fortawesome/free-solid-svg-icons';

import { UsuarioService } from '../../../services/usuario.service';
import { Usuario } from '../../../models/usuario';

@Component({
  selector: 'app-registra-usuario',
  templateUrl: './registra-usuario.component.html',
  styleUrl: './registra-usuario.component.scss'
})
export class RegistraUsuarioComponent {
  user = {} as Usuario;

  icCancel = faXmark;
  icAdd = faPlus;

  constructor(private service: UsuarioService, private router: Router) {}

  addUser(): void {
    this.service.postUsuario(this.user)
      .subscribe(() => {
        console.log(this.user);
        alert('Usuario cadastrado com sucesso!');
        this.router.navigate(['/Usuarios']);
      });
  }
}