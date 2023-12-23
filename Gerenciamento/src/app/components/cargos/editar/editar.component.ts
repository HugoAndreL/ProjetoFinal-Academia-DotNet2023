import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { faCheck, faXmark } from '@fortawesome/free-solid-svg-icons';

import { CargoService } from '../../../services/cargo.service';
import { Cargo } from '../../../models/cargo';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrl: './editar.component.scss'
})
export class EditarComponent {
  cargo = {} as Cargo;
  form!: FormGroup;

  icCancel = faXmark;
  icCheck = faCheck;

  constructor(private route: ActivatedRoute, private router: Router, private service: CargoService, private builder: FormBuilder) {
    this.form = this.builder.group({
      id: null,
      nome: null
    });
  }
  
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.service.getCargobyId(parseInt(id!)).subscribe((cargo) => {
      this.form.patchValue({
        id: id,
        nome: cargo.nome
      });
    });
  }

  updateUser(): void {
    this.service.putCargo(this.form.value).subscribe(() => {
      alert('Cargo alterado com sucesso!');
      this.router.navigate(['/Cargos']);
    });
  }
}
