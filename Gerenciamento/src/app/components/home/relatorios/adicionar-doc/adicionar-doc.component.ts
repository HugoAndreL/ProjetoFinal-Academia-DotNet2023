import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { faPlus, faXmark } from '@fortawesome/free-solid-svg-icons';

import { RelatorioService } from '../../../../services/relatorio.service';
import { Relatorio } from '../../../../models/relatorio';

@Component({
  selector: 'app-adicionar-doc',
  templateUrl: './adicionar-doc.component.html',
  styleUrl: './adicionar-doc.component.scss'
})
export class AdicionarDocComponent {
  frmRel!: FormGroup;
  rel = {} as Relatorio;

  icCancel = faXmark;
  icAdd = faPlus;

  constructor(private service: RelatorioService, private router: Router) {}

  ngOnInit() {
    this.frmRel = new FormGroup({
      id: new FormControl(''),
      tempoEspera: new FormControl('',
        [Validators.required, Validators.maxLength(10)]),
      taxaGuiche: new FormControl('',
        [Validators.required]),
      taxaTriagem: new FormControl('',
        [Validators.required]),
      taxaConsultorio: new FormControl('',
        [Validators.required])
    });
  }

  addRelatorio(): void {
    this.service.postRelatorio(this.rel)
      .subscribe(() => {
        alert('Relatório cadastrado com sucesso!');
        this.router.navigate(['Home/Relatorios']);
      });
  }
}
