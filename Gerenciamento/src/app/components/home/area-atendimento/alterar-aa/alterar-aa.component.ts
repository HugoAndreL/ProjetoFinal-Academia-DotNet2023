import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';

import { faCheck, faXmark } from '@fortawesome/free-solid-svg-icons';

import { AreaAtendimentoService } from '../../../../services/area-atendimento.service';
import { AreaAtendimento } from '../../../../models/area-atendimento';

@Component({
  selector: 'app-alterar-aa',
  templateUrl: './alterar-aa.component.html',
  styleUrl: './alterar-aa.component.scss'
})
export class AlterarAaComponent {
  aa = {} as AreaAtendimento;
  frmAa!: FormGroup;

  icCancel = faXmark;
  icCheck = faCheck;

  constructor(private route: ActivatedRoute, private router: Router, private service: AreaAtendimentoService, private builder: FormBuilder) {
    this.frmAa = this.builder.group({
      id: null,
      nome: null,
      tipoAreaAtendimentoId: null,
    });
  }
  
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.service.getAreaAtendimentobyId(parseInt(id!)).subscribe((aa) => {
      this.frmAa.patchValue({
        id: id,
        nome: aa.nome,
        tipoAreaAtendimentoId: aa.tipoAreaAtendimentoId
      });
      this.aa = aa
    });
  }

  updateAreaAtendimento(): void {
    this.service.putAreaAtendimento(this.frmAa.value)
      .subscribe((aa) => {
        alert(`${aa.nome} alterado com sucesso!`);
        this.router.navigate(['Home/AreasAtendimento']);
      });
  }
}