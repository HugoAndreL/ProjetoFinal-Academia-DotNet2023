import { Component } from '@angular/core';
import { faPlus, faXmark } from '@fortawesome/free-solid-svg-icons';
import { FuncionalidadeService } from '../../../../services/funcionalidade.service';
import { Router } from '@angular/router';
import { Funcionalidade } from '../../../../models/funcionalidade';


@Component({
  selector: 'app-adicionar-func',
  templateUrl: './adicionar-func.component.html',
  styleUrl: './adicionar-func.component.scss'
})
export class AdicionarFuncComponent {
  func = {} as Funcionalidade;

  icCancel = faXmark;
  icAdd = faPlus;

  constructor(private service: FuncionalidadeService, private router: Router) {}

  addFuncionalidade(): void {
    this.service.postFuncionalidade(this.func)
      .subscribe(() => {
        alert('Funcionalidade cadastrada com sucesso!');
        this.router.navigate(['Home/Funcionalidades']);
      });
  }
}
