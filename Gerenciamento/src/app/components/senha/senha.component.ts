import { Component } from '@angular/core';

import { Senha } from '../../models/senha';
import { SenhaService } from '../../services/senha.service';

import { faArrowDown, faArrowUp, faFileCirclePlus, faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-senha',
  templateUrl: './senha.component.html',
  styleUrl: './senha.component.scss'
})
export class SenhaComponent {
  senhas: Senha[] = [];
  senha = {} as Senha;

  icTrash = faTrash;
  icOrdemAcima = faArrowUp;
  icOrdemAbaixo = faArrowDown;

  constructor(private service: SenhaService) {}

  ngOnInit() {
    this.readSenhas();
  }
  
  readSenhas() {
    this.service.getSenhas().subscribe((senhas: Senha[]) => {
      this.senhas = senhas;
    });
  }

  addSenha(value: string) {
    value == '1' ? "Normal" : "Prioritario";
    this.senha.prioridade = value;
    this.service.postSenha(this.senha)
    .subscribe(() => {
      this.readSenhas();
    })
  }

  excluirSenha(senha: Senha) {
    this.service.deleteSenha(senha).subscribe(() => {
      alert(`Senha: ${senha.numero} deletado com sucesso`);
      this.readSenhas();
    })
  }
}
