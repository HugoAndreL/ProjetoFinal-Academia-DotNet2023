import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { faPlus, faXmark } from '@fortawesome/free-solid-svg-icons';

import { AreaAtendimentoService } from '../../../../services/area-atendimento.service';
import { AreaAtendimento } from '../../../../models/area-atendimento';

@Component({
  selector: 'app-adicionar-aa',
  templateUrl: './adicionar-aa.component.html',
  styleUrl: './adicionar-aa.component.scss'
})
export class AdicionarAaComponent {
  frmAa!: FormGroup;
  aa = {} as AreaAtendimento;
  
  icCancel = faXmark;
  icAdd = faPlus;

  constructor(private service: AreaAtendimentoService, private router: Router) {}

  ngOnInit() {
    this.frmAa = new FormGroup({
      id: new FormControl(''),
      nome: new FormControl('',
        [Validators.required, Validators.maxLength(50)]),
      tipoAreaAtendimentoId: new FormControl('',
        [Validators.required]) 
    });
  }

  addAreaAtendimento(): void {
    this.service.postAreaAtendimento(this.aa)
      .subscribe(() => {
        alert('Area de Atendimento cadastrado com sucesso!');
        this.router.navigate(['Home/AreasAtendimento']);
      });
  }
}