import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { faPlus, faXmark } from '@fortawesome/free-solid-svg-icons';

import { FuncionalidadeService } from '../../../../services/funcionalidade.service';
import { Funcionalidade } from '../../../../models/funcionalidade';

@Component({
  selector: 'app-adicionar-func',
  templateUrl: './adicionar-func.component.html',
  styleUrl: './adicionar-func.component.scss'
})
export class AdicionarFuncComponent {
  func = {} as Funcionalidade;
  frmFunc!: FormGroup;

  icCancel = faXmark;
  icAdd = faPlus;

  constructor(private service: FuncionalidadeService, private router: Router) {}

  ngOnInit() {
    this.frmFunc = new FormGroup({
      id: new FormControl(''),
      nome: new FormControl('', 
      [Validators.required]),
      cargoId: new FormControl('',
      [Validators.required])
    });
  }

  addFuncionalidade(): void {
    this.service.postFuncionalidade(this.func)
      .subscribe(() => {
        alert('Funcionalidade cadastrada com sucesso!');
        this.router.navigate(['Home/Funcionalidades']);
      });
  }
}
