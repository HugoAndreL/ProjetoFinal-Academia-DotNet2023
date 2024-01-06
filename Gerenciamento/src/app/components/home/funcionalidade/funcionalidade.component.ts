import { Component } from '@angular/core';

import { faKey, faPenToSquare, faPlus } from '@fortawesome/free-solid-svg-icons';

import { Funcionalidade } from '../../../models/funcionalidade';
import { FuncionalidadeService } from '../../../services/funcionalidade.service';

@Component({
  selector: 'app-funcionalidade',
  templateUrl: './funcionalidade.component.html',
  styleUrl: './funcionalidade.component.scss'
})
export class FuncionalidadeComponent {
  funcionalidades: Funcionalidade[] = [];

  icEdit = faPenToSquare;
  icAssocia = faKey;
  icAdd = faPlus;

  constructor(private service: FuncionalidadeService) {}

  ngOnInit() {
    this.readFuncionalidades();
  }

  readFuncionalidades() {
    this.service.getFuncionalidade().subscribe((funcionalidades: Funcionalidade[]) => {
      this.funcionalidades = funcionalidades;
    });
  }
}
