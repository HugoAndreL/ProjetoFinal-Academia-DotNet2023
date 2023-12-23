import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { CargoService } from '../../../services/cargo.service';
import { Cargo } from '../../../models/cargo';

@Component({
  selector: 'app-remover',
  templateUrl: './remover.component.html',
  styleUrl: './remover.component.scss'
})
export class RemoverComponent {
  cargo = {} as Cargo
  
  constructor(private route: ActivatedRoute, private router: Router, private service: CargoService) {}
  
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.service.getCargobyId(parseInt(id!)).subscribe((cargo) => {
      this.cargo = cargo;
    });
  }

  removerCargo() {
    this.service.deleteCargo(this.cargo).subscribe(() => {
      alert(`${this.cargo.nome} deletado com sucesso`);
      this.router.navigate(['/Cargos']);
    })
  }
}
