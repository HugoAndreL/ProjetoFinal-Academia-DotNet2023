import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';

import { faCheck, faXmark } from '@fortawesome/free-solid-svg-icons';

import emailjs from '@emailjs/browser';

import { UsuarioService } from '../../../../services/usuario.service';
import { Usuario } from '../../../../models/usuario';

@Component({
  selector: 'app-alterar-usuario',
  templateUrl: './alterar-usuario.component.html',
  styleUrl: './alterar-usuario.component.scss'
})
export class AlterarUsuarioComponent {
  user = {} as Usuario;
  frmUser!: FormGroup;

  icCancel = faXmark;
  icCheck = faCheck;

  constructor(private route: ActivatedRoute, private router: Router, private service: UsuarioService, private builder: FormBuilder) {
    this.frmUser = this.builder.group({
      id: null,
      nome: null,
      email: null,
      cargoId: null,
      senha: null
    });
  }
  
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.service.getUsuariobyId(parseInt(id!))
      .subscribe((user) => {
        this.frmUser.patchValue({
          id: id,
          nome: user.nome,
          email: user.email,
          cargoId: user.cargoId,
          senha: user.senha
        });
        this.user = user;
      });
  }

  updateUser(): void {
    this.service.putUsuario(this.frmUser.value)
      .subscribe((user) => {
        alert(`${user.nome} alterado com sucesso!`);
        this.router.navigate(['Home/Usuarios']);

        // Gerando o email com o novo usuário e senha para login
        emailjs.init("YWCD2Lh3vwYpBL967");
        emailjs.send("HospitalSGS.outlook","template_cv36wj8",{
          nome: user.nome,
          email: user.email,
          senha: user.senha,
          site: "http://localhost:4200/"
        });
    });
  }
}
