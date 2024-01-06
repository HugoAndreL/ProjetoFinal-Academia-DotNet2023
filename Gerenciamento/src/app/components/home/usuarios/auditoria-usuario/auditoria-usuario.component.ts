import { Component } from '@angular/core';

import { AuditoriaUsuarios } from '../../../../models/auditoria-usuarios';
import { AuditoriaService } from '../../../../services/auditoria.service';

@Component({
  selector: 'app-auditoria-usuario',
  templateUrl: './auditoria-usuario.component.html',
  styleUrl: './auditoria-usuario.component.scss'
})
export class AuditoriaUsuarioComponent {
  users: AuditoriaUsuarios[] = [];

  constructor(private service: AuditoriaService) {}

  ngOnInit() {
    this.readUsuarios();
  }

  readUsuarios() {
    this.service.getUsuarios().subscribe((user: AuditoriaUsuarios[]) => {
      this.users = user;
    });
  }
}
