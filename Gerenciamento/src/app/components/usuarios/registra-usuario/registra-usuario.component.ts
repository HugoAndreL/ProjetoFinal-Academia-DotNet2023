import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { faPlus, faXmark } from '@fortawesome/free-solid-svg-icons';

import emailjs from '@emailjs/browser';

import { UsuarioService } from '../../../services/usuario.service';
import { Usuario } from '../../../models/usuario';

@Component({
  selector: 'app-registra-usuario',
  templateUrl: './registra-usuario.component.html',
  styleUrl: './registra-usuario.component.scss'
})
export class RegistraUsuarioComponent {
  user = {} as Usuario;

  icCancel = faXmark;
  icAdd = faPlus;

  constructor(private service: UsuarioService, private router: Router) {}

  addUser(): void {
    this.service.postUsuario(this.user)
      .subscribe(() => {
        alert('Usuario cadastrado com sucesso!');
        this.router.navigate(['/Usuarios']);

        // Gerando a senha para o email
        let nomeSenha = this.user.nome.toLowerCase().split(" ");
        // Gerando o email
        emailjs.init("YWCD2Lh3vwYpBL967");
        emailjs.send("HospitalSGS.outlook","template_9ilfrge",{
          nome: this.user.nome,
          email: this.user.email,
          senha: `Hospital@${nomeSenha[0]}.${nomeSenha[nomeSenha.length - 1]}`,
          site: "http://localhost:4200/"
        });
      });
    }
}