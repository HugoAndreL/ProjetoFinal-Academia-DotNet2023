import { Component } from '@angular/core';
import { faPenToSquare, faPlus, faTrash } from '@fortawesome/free-solid-svg-icons';

import { TipoAreaAtendimento } from '../../../models/tipo-area-atendimento';
import { TipoAreaAtendimentoService } from '../../../services/tipo-area-atendimento.service';

@Component({
  selector: 'app-tipo-area-atendimento',
  templateUrl: './tipo-area-atendimento.component.html',
  styleUrl: './tipo-area-atendimento.component.scss'
})
export class TipoAreaAtendimentoComponent {
  taas: TipoAreaAtendimento[] = [];

  icEdit = faPenToSquare;
  icDesativar = faTrash;
  icAdd = faPlus;

  constructor(private service: TipoAreaAtendimentoService) {}

  ngOnInit() {
    this.readTiposAreasAtendimento();
  }

  readTiposAreasAtendimento() {
    this.service.getTiposAreasAtendimento().subscribe((taas: TipoAreaAtendimento[]) => {
      this.taas = taas;
    });
  }
}
