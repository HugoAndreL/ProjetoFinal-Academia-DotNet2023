import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { faArrowLeft, faCheck, faPlus, faXmark } from '@fortawesome/free-solid-svg-icons';

import { Cargo } from '../../../models/cargo';
import { CargoService } from '../../../services/cargo.service';

@Component({
  selector: 'app-adicionar',
  templateUrl: './adicionar.component.html',
  styleUrl: './adicionar.component.scss'
})
export class AdicionarComponent {
  cargo = {} as Cargo;

  icCancel = faXmark;
  icAdd = faPlus;

  constructor(private service: CargoService, private router: Router) {}

  addUser(): void {
    this.service.postCargo(this.cargo)
      .subscribe(() => {
        console.log(this.cargo);
        alert('Cargo cadastrado com sucesso!');
        this.router.navigate(['/Cargos']);
      });
  }
}
