import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { faPlus, faXmark } from '@fortawesome/free-solid-svg-icons';

import { CargoService } from '../../../../services/cargo.service';
import { Cargo } from '../../../../models/cargo';

@Component({
  selector: 'app-adicionar-cargo',
  templateUrl: './adicionar-cargo.component.html',
  styleUrl: './adicionar-cargo.component.scss'
})
export class AdicionarCargoComponent {
  cargo = {} as Cargo;
  frmCargo!: FormGroup;

  icCancel = faXmark;
  icAdd = faPlus;

  constructor(private service: CargoService, private router: Router) {}

  ngOnInit() {
    this.frmCargo = new FormGroup({
      id: new FormControl(''),
      nome: new FormControl('',
        [Validators.required, Validators.maxLength(50)])
    });
  }

  addCargo(): void {
    this.service.postCargo(this.cargo)
      .subscribe(() => {
        alert('Cargo cadastrado com sucesso!');
        this.router.navigate(['Home/Cargos']);
      });
  }
}