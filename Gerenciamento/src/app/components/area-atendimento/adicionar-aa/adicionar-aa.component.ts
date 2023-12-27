import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { faPlus, faXmark } from '@fortawesome/free-solid-svg-icons';

import { AreaAtendimento } from '../../../models/area-atendimento';
import { AreaAtendimentoService } from '../../../services/area-atendimento.service';

@Component({
  selector: 'app-adicionar-aa',
  templateUrl: './adicionar-aa.component.html',
  styleUrl: './adicionar-aa.component.scss'
})
export class AdicionarAaComponent {
  aa = {} as AreaAtendimento;

  icCancel = faXmark;
  icAdd = faPlus;

  constructor(private service: AreaAtendimentoService, private router: Router) {}

  addAreaAtendimento(): void {
    this.service.postAreaAtendimento(this.aa)
      .subscribe(() => {
        alert('Area de Atendimento cadastrado com sucesso!');
        this.router.navigate(['/AreasAtendimento']);
      });
  }
}
