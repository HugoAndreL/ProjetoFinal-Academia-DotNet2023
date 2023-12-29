import { Component } from '@angular/core';

import { Senha } from '../../models/senha';
import { SenhaService } from '../../services/senha.service';

import { faArrowDown, faArrowUp, faFileCirclePlus } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-senha',
  templateUrl: './senha.component.html',
  styleUrl: './senha.component.scss'
})
export class SenhaComponent {
  senhas: Senha[] = [];
  rel = {} as Senha;

  icAdd = faFileCirclePlus;
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

  addSenha() {}
}
