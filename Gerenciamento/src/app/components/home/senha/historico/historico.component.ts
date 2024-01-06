import { Component } from '@angular/core';

import { Historico } from '../../../../models/historico';
import { HistoricoService } from '../../../../services/historico.service';

@Component({
  selector: 'app-historico',
  templateUrl: './historico.component.html',
  styleUrl: './historico.component.scss'
})
export class HistoricoComponent {
  historicos: Historico[] = [];

  constructor(private service: HistoricoService) {}

  ngOnInit() {
    this.readHistoricos();
  }

  readHistoricos() {
    this.service.getSenhas().subscribe((historicos: Historico[]) => {
      this.historicos = historicos;
    });
  }
}
