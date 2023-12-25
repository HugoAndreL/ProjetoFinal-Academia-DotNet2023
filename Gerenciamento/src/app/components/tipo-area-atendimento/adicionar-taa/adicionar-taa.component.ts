import { Component } from '@angular/core';
import { TipoAreaAtendimentoService } from '../../../services/tipo-area-atendimento.service';

import { faPlus, faXmark } from '@fortawesome/free-solid-svg-icons';
import { TipoAreaAtendimento } from '../../../models/tipo-area-atendimento';
import { Router } from '@angular/router';

@Component({
  selector: 'app-adicionar-taa',
  templateUrl: './adicionar-taa.component.html',
  styleUrl: './adicionar-taa.component.scss'
})
export class AdicionarTaaComponent {
  taa = {} as TipoAreaAtendimento;

  icCancel = faXmark;
  icAdd = faPlus;

  constructor(private service: TipoAreaAtendimentoService, private router: Router) {}

  addTipoAreaAtendimento(): void {
    this.service.postTipoAreaAtendimento(this.taa)
      .subscribe(() => {
        console.log(this.taa);
        alert('Tipo de Area de Atendimento cadastrado com sucesso!');
        this.router.navigate(['/TiposAreasAtendimento']);
      });
  }
}
