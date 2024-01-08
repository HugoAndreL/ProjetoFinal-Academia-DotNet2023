import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { faCheck, faXmark } from '@fortawesome/free-solid-svg-icons';

import { TipoAreaAtendimento } from '../../../../models/tipo-area-atendimento';
import { TipoAreaAtendimentoService } from '../../../../services/tipo-area-atendimento.service';

@Component({
  selector: 'app-alterar-taa',
  templateUrl: './alterar-taa.component.html',
  styleUrl: './alterar-taa.component.scss'
})
export class AlterarTaaComponent {
  taa = {} as TipoAreaAtendimento;
  frmTaa!: FormGroup;

  icCancel = faXmark;
  icCheck = faCheck;

  constructor(private route: ActivatedRoute, private router: Router, private service: TipoAreaAtendimentoService, private builder: FormBuilder) {
    this.frmTaa = this.builder.group({
      id: null,
      nome: null
    });
  }
  
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.service.getTipoAreaAtendimentobyId(parseInt(id!))
      .subscribe((taa) => {
        this.frmTaa.patchValue({
          id: id,
          nome: taa.nome
        });
        this.taa = taa;
      });
  }

  updateTipoAreaAtendimento(): void {
    this.service.putTipoAreaAtendimento(this.frmTaa.value)
      .subscribe((taa) => {
        alert(`${taa.nome} alterado com sucesso!`);
        this.router.navigate(['Home/TiposAreasAtendimento']);
      });
  }
}