import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { faFileCirclePlus, faFileCsv } from '@fortawesome/free-solid-svg-icons';

import { Relatorio } from '../../models/relatorio';
import { RelatorioService } from '../../services/relatorio.service';

@Component({
  selector: 'app-relatorios',
  templateUrl: './relatorios.component.html',
  styleUrl: './relatorios.component.scss'
})
export class RelatoriosComponent {
  rels: Relatorio[] = [];
  rel = {} as Relatorio;

  icAdd = faFileCirclePlus;
  icCsv = faFileCsv;

  constructor(private service: RelatorioService) {}

  ngOnInit() {
    this.readTiposAreasAtendimento();
  }
  
  readTiposAreasAtendimento() {
    this.service.getRelatorios().subscribe((rels: Relatorio[]) => {
      this.rels = rels;
    });
  }
  
  GerarCsv(rel: Relatorio) {
    this.service.getCsv(rel).subscribe(() => {
      alert(`Arquivo gerado com nome de ${rel.nome}.csv!`);
    })
  }
}
