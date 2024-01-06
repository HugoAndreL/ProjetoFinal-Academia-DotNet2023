import { Component } from '@angular/core';

import { Cargo } from '../../../../models/cargo';
import { AuditoriaService } from '../../../../services/auditoria.service';

@Component({
  selector: 'app-auditoria-cargos',
  templateUrl: './auditoria-cargos.component.html',
  styleUrl: './auditoria-cargos.component.scss'
})
export class AuditoriaCargosComponent {
  cargos: Cargo[] = [];

  constructor(private service: AuditoriaService) {}

  ngOnInit() {
    this.readCargos();
  }

  readCargos() {
    this.service.getCargos().subscribe((cargos: Cargo[]) => {
      this.cargos = cargos;
    });
  }
}
