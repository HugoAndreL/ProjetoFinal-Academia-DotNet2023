import { Component } from '@angular/core';
import { Funcionalidade } from '../../../models/funcionalidade';
import { FormBuilder, FormGroup } from '@angular/forms';
import { faCheck, faXmark } from '@fortawesome/free-solid-svg-icons';
import { ActivatedRoute, Router } from '@angular/router';
import { FuncionalidadeService } from '../../../services/funcionalidade.service';

@Component({
  selector: 'app-assoicar-func',
  templateUrl: './assoicar-func.component.html',
  styleUrl: './assoicar-func.component.scss'
})
export class AssoicarFuncComponent {
  func = {} as Funcionalidade;
  form!: FormGroup;

  icCancel = faXmark;
  icCheck = faCheck;

  constructor(private route: ActivatedRoute, private router: Router, private service: FuncionalidadeService, private builder: FormBuilder) {
    this.form = this.builder.group({
      id: null,
      nome: null,
      cargoId: null
    });
  }
  
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.service.getFuncionalidadebyId(parseInt(id!)).subscribe((func) => {
      this.form.patchValue({
        id: id,
        nome: func.nome,
        cargoId: func.cargoId
      });
    });
  }

  associar() {
    this.service.patchFunciolidade(this.form.value).subscribe(() => {
      alert('Fucionalidade alterada com sucesso');
      this.router.navigate(['/Funcionalidades'])
    })
  }

  desassociar() {

  }
}
