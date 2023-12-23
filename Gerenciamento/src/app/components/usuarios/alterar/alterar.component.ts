import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';

import { faCheck, faXmark } from '@fortawesome/free-solid-svg-icons';

import { UsuarioService } from '../../../services/usuario.service';
import { Usuario } from '../../../models/usuario';

@Component({
  selector: 'app-alterar',
  templateUrl: './alterar.component.html',
  styleUrl: './alterar.component.scss'
})
export class AlterarComponent {
  user = {} as Usuario;
  form!: FormGroup;

  icCancel = faXmark;
  icCheck = faCheck;

  constructor(private route: ActivatedRoute, private router: Router, private service: UsuarioService, private builder: FormBuilder) {
    this.form = this.builder.group({
      id: null,
      nome: null,
      email: null,
      cargoId: null,
      senha: null
    });
  }
  
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.service.getCargobyId(parseInt(id!)).subscribe((user) => {
      this.form.patchValue({
        id: id,
        nome: user.nome,
        email: user.email,
        cargoId: user.cargoId,
        senha: user.senha
      });
    });
  }

  updateUser(): void {
    this.service.putUsuario(this.form.value).subscribe(() => {
      alert('Alterado com sucesso!');
      this.router.navigate(['/Usuarios']);
    });
  }
}
