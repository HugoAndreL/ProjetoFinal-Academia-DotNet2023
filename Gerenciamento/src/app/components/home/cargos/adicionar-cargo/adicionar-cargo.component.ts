import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { faPlus, faXmark } from '@fortawesome/free-solid-svg-icons';

import { Cargo } from '../../../../models/cargo';
import { CargoService } from '../../../../services/cargo.service';

@Component({
  selector: 'app-adicionar-cargo',
  templateUrl: './adicionar-cargo.component.html',
  styleUrl: './adicionar-cargo.component.scss'
})
export class AdicionarCargoComponent {
  cargo = {} as Cargo;

  icCancel = faXmark;
  icAdd = faPlus;

  constructor(private service: CargoService, private router: Router) {}

  addCargo(): void {
    this.service.postCargo(this.cargo)
      .subscribe(() => {
        alert('Cargo cadastrado com sucesso!');
        this.router.navigate(['Home/Cargos']);
      });
  }
}
