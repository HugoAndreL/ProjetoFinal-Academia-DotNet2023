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
  form!: FormGroup;

  icCancel = faXmark;
  icCheck = faCheck;

  constructor(private route: ActivatedRoute, private router: Router, private service: TipoAreaAtendimentoService, private builder: FormBuilder) {
    this.form = this.builder.group({
      id: null,
      nome: null,
      email: null,
      cargoId: null,
      senha: null
    });
  }
  
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.service.getTipoAreaAtendimentobyId(parseInt(id!)).subscribe((taa) => {
      this.form.patchValue({
        id: id,
        nome: taa.nome
      });
    });
  }

  updateTipoAreaAtendimento(): void {
    this.service.putTipoAreaAtendimento(this.form.value).subscribe(() => {
      alert('Tipo de Area de Atendimento alterado com sucesso!');
      this.router.navigate(['Home/TiposAreasAtendimento']);
    });
  }
}
