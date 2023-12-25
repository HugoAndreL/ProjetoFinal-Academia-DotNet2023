import { Component } from '@angular/core';
import { Cargo } from '../../../models/cargo';
import { CargoService } from '../../../services/cargo.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-desativar-cargo',
  templateUrl: './desativar-cargo.component.html',
  styleUrl: './desativar-cargo.component.scss'
})
export class DesativarCargoComponent {
  cargo = {} as Cargo;
  
  constructor(private route: ActivatedRoute, private router: Router, private service: CargoService) {}
  
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.service.getCargobyId(parseInt(id!)).subscribe((cargo) => {
      this.cargo = cargo;
    });
  }

  desativarCargo() {
    this.service.deleteCargo(this.cargo).subscribe(() => {
      alert(`${this.cargo.nome} deletado com sucesso`);
      this.router.navigate(['/Cargos']);
    })
  }
}
