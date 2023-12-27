import { Component } from '@angular/core';
import { Cargo } from '../../../models/cargo';
import { faPlus, faXmark } from '@fortawesome/free-solid-svg-icons';
import { CargoService } from '../../../services/cargo.service';
import { Router } from '@angular/router';

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
        this.router.navigate(['/Cargos']);
      });
  }
}
