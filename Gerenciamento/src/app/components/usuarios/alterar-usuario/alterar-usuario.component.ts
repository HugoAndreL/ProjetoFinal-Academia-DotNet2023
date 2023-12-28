import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Usuario } from '../../../models/usuario';
import { FormBuilder, FormGroup } from '@angular/forms';

import { faCheck, faXmark } from '@fortawesome/free-solid-svg-icons';

import emailjs from '@emailjs/browser';

import { UsuarioService } from '../../../services/usuario.service';

@Component({
  selector: 'app-alterar-usuario',
  templateUrl: './alterar-usuario.component.html',
  styleUrl: './alterar-usuario.component.scss'
})
export class AlterarUsuarioComponent {
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
    this.service.getUsuariobyId(parseInt(id!)).subscribe((user) => {
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

      emailjs.init("YWCD2Lh3vwYpBL967");
      emailjs.send("HospitalSGS.outlook","template_cv36wj8",{
        nome: this.form.value.nome,
        email: this.form.value.email,
        senha: this.form.value.senha,
        site: "http://localhost:4200/"
      });
    });
  }
}
