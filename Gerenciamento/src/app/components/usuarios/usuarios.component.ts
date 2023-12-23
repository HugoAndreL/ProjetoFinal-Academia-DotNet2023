import { Component } from '@angular/core';

import { faPenToSquare, faTrashArrowUp, faUserPlus } from '@fortawesome/free-solid-svg-icons';

import { Usuario } from '../../models/usuario';
import { UsuarioService } from '../../services/usuario.service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrl: './usuarios.component.scss'
})
export class UsuariosComponent {
  users: Usuario[] = [];

  icEdit = faPenToSquare;
  icDesativar = faTrashArrowUp;
  icAdd = faUserPlus;

  constructor(private service: UsuarioService) {}

  ngOnInit() {
    this.readCargos();
  }

  readCargos() {
    this.service.getUsuarios().subscribe((users: Usuario[]) => {
      this.users = users;
    });
  }
}
