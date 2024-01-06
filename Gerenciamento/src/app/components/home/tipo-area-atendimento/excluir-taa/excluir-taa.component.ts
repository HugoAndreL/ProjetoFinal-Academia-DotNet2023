import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { TipoAreaAtendimento } from '../../../../models/tipo-area-atendimento';
import { TipoAreaAtendimentoService } from '../../../../services/tipo-area-atendimento.service';

@Component({
  selector: 'app-excluir-taa',
  templateUrl: './excluir-taa.component.html',
  styleUrl: './excluir-taa.component.scss'
})
export class ExcluirTaaComponent {
  taa = {} as TipoAreaAtendimento;
  
  constructor(private route: ActivatedRoute, private router: Router, private service: TipoAreaAtendimentoService) {}
  
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.service.getTipoAreaAtendimentobyId(parseInt(id!)).subscribe((taa) => {
      this.taa = taa;
    });
  }

  excluirTaa() {
    this.service.deleteTipoAreaAtendimento(this.taa).subscribe(() => {
      alert(`${this.taa.nome} deletado com sucesso`);
      this.router.navigate(['Home/TiposAreasAtendimento']);
    })
  }
}
