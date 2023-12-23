import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { UsuarioService } from '../../../services/usuario.service';
import { Usuario } from '../../../models/usuario';

@Component({
  selector: 'app-desativar',
  templateUrl: './desativar.component.html',
  styleUrl: './desativar.component.scss'
})
export class DesativarComponent {
  user = {} as Usuario;
  
  constructor(private route: ActivatedRoute, private router: Router, private service: UsuarioService) {}
  
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.service.getCargobyId(parseInt(id!)).subscribe((user) => {
      this.user = user;
    });
  }

  desativarCargo() {
    this.service.deleteUsuario(this.user).subscribe(() => {
      alert(`${this.user.nome} deletado com sucesso`);
      this.router.navigate(['/Usuarios']);
    })
  }
}
