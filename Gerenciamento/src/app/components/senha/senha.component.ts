import { Component } from '@angular/core';

import { Senha } from '../../models/senha';
import { SenhaService } from '../../services/senha.service';

import { faArrowDown, faArrowUp, faTrash } from '@fortawesome/free-solid-svg-icons';
import { Historico } from '../../models/historico';
import { Router } from '@angular/router';

@Component({
  selector: 'app-senha',
  templateUrl: './senha.component.html',
  styleUrl: './senha.component.scss'
})
export class SenhaComponent {
  senhas: Senha[] = [];
  senha = {} as Senha;
  senhaRechamada = {} as Historico;
  senhaChamada = {} as Senha;
  
  icTrash = faTrash;
  icOrdemAcima = faArrowUp;
  icOrdemAbaixo = faArrowDown;

  constructor(private service: SenhaService, private router: Router) {}

  ngOnInit() {
    this.readSenhas();
  }
  
  readSenhas() {
    this.service.getSenhas().subscribe((senhas: Senha[]) => {
      this.senhas = senhas;
    });
  }

  addSenha(value: string) {
    value == '1' ? "Normal" : "Prioritaria";
    this.senha.prioridade = value;
    this.service.postSenha(this.senha)
    .subscribe(() => {
      this.readSenhas();
    });
  }

  excluirSenha(senha: Senha) {
    this.service.deleteSenha(senha).subscribe(() => {
      alert(`Senha: ${senha.id} deletado com sucesso`);
      this.readSenhas();
    });
  }
  
  proximaSenha() {
    this.service.getSenha().subscribe((senha: Senha) => {
      this.senhaChamada.id = senha.id;
      this.senhaChamada.prioridade = senha.prioridade == '2' ? "Prioritaria" : "Normal";
      this.readSenhas();
    });
  }

  rechamarSenha() {
    this.service.getHistorico().subscribe((senha: Historico) => {
      this.senhaChamada.id = senha.id;
      this.senhaChamada.prioridade = senha.prioridade == '2' ? "Prioritaria" : "Normal";
      this.readSenhas();
    })
  }
}