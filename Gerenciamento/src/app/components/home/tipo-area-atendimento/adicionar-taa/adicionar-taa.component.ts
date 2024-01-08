import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { faPlus, faXmark } from '@fortawesome/free-solid-svg-icons';

import { TipoAreaAtendimento } from '../../../../models/tipo-area-atendimento';
import { TipoAreaAtendimentoService } from '../../../../services/tipo-area-atendimento.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-adicionar-taa',
  templateUrl: './adicionar-taa.component.html',
  styleUrl: './adicionar-taa.component.scss'
})
export class AdicionarTaaComponent {
  taa = {} as TipoAreaAtendimento;
  frmTaa!: FormGroup;

  icCancel = faXmark;
  icAdd = faPlus;

  constructor(private service: TipoAreaAtendimentoService, private router: Router) {}

  ngOnInit() {
    this.frmTaa = new FormGroup({
      id: new FormControl(''),
      nome: new FormControl('',
        [Validators.required, Validators.maxLength(50)]),
    });
  }

  addTipoAreaAtendimento(): void {
    this.service.postTipoAreaAtendimento(this.taa)
      .subscribe(() => {
        alert('Tipo de Area de Atendimento cadastrado com sucesso!');
        this.router.navigate(['Home/TiposAreasAtendimento']);
      });
  }
}
