import { Component } from '@angular/core';

import { faPenToSquare, faPlus, faTrashArrowUp } from '@fortawesome/free-solid-svg-icons'

import { Cargo } from '../../models/cargo';
import { CargoService } from '../../services/cargo.service';

@Component({
  selector: 'app-cargos',
  templateUrl: './cargos.component.html',
  styleUrl: './cargos.component.scss'
})
export class CargosComponent {
  cargos: Cargo[] = [];

  icEdit = faPenToSquare;
  icDesativar = faTrashArrowUp;
  icAdd = faPlus;

  constructor(private service: CargoService) {}

  ngOnInit() {
    this.readCargos();
  }

  readCargos() {
    this.service.getCargos().subscribe((cargos: Cargo[]) => {
      this.cargos = cargos;
    });
  }
}
