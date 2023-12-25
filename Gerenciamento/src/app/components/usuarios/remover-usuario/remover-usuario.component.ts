import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Usuario } from '../../../models/usuario';
import { UsuarioService } from '../../../services/usuario.service';

@Component({
  selector: 'app-remover-usuario',
  templateUrl: './remover-usuario.component.html',
  styleUrl: './remover-usuario.component.scss'
})
export class RemoverUsuarioComponent {
  user = {} as Usuario;
  
  constructor(private route: ActivatedRoute, private router: Router, private service: UsuarioService) {}
  
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.service.getUsuariobyId(parseInt(id!)).subscribe((user) => {
      this.user = user;
    });
  }

  desativarUsuario() {
    this.service.deleteUsuario(this.user).subscribe(() => {
      alert(`${this.user.nome} deletado com sucesso`);
      this.router.navigate(['/Usuarios']);
    })
  }
}
