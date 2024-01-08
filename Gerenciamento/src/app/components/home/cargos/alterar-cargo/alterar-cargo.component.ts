import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { faCheck, faXmark } from '@fortawesome/free-solid-svg-icons';

import { Cargo } from '../../../../models/cargo';
import { CargoService } from '../../../../services/cargo.service';

@Component({
  selector: 'app-alterar-cargo',
  templateUrl: './alterar-cargo.component.html',
  styleUrl: './alterar-cargo.component.scss'
})
export class AlterarCargoComponent {
  cargo = {} as Cargo;
  frmCargo!: FormGroup;

  icCancel = faXmark;
  icCheck = faCheck;

  constructor(private route: ActivatedRoute, private router: Router, private service: CargoService, private builder: FormBuilder) {
    this.frmCargo = this.builder.group({
      id: null,
      nome: null,
      email: null,
      cargoId: null,
      senha: null
    });
  }
  
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.service.getCargobyId(parseInt(id!))
      .subscribe((cargo) => {
        this.frmCargo.patchValue({
          id: id,
          nome: cargo.nome
        });
        this.cargo = cargo
    });
  }

  updateCargo(): void {
    this.service.putCargo(this.frmCargo.value)
      .subscribe((cargo) => {
        alert(`${cargo.nome} alterado com sucesso!`);
        this.router.navigate(['Home/Cargos']);
      });
  }
}
