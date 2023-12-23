import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { faPlus, faXmark } from '@fortawesome/free-solid-svg-icons';

import { Usuario } from '../../../models/usuario';
import { UsuarioService } from '../../../services/usuario.service';

@Component({
  selector: 'app-registrar',
  templateUrl: './registrar.component.html',
  styleUrl: './registrar.component.scss'
})
export class RegistrarComponent {
  user = {} as Usuario;

  icCancel = faXmark;
  icAdd = faPlus;

  constructor(private service: UsuarioService, private router: Router) {}

  addUser(): void {
    this.service.postUsuario(this.user)
      .subscribe(() => {
        alert('Usuário cadastrado com sucesso!');
        this.router.navigate(['/Usuarios']);
      });
  }
}
