import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { faCheck, faXmark } from '@fortawesome/free-solid-svg-icons';

import { AreaAtendimento } from '../../../models/area-atendimento';
import { AreaAtendimentoService } from '../../../services/area-atendimento.service';

@Component({
  selector: 'app-alterar-aa',
  templateUrl: './alterar-aa.component.html',
  styleUrl: './alterar-aa.component.scss'
})
export class AlterarAaComponent {
  aa = {} as AreaAtendimento;
  form!: FormGroup;

  icCancel = faXmark;
  icCheck = faCheck;

  constructor(private route: ActivatedRoute, private router: Router, private service: AreaAtendimentoService, private builder: FormBuilder) {
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
    this.service.getAreaAtendimentobyId(parseInt(id!)).subscribe((taa) => {
      this.form.patchValue({
        id: id,
        nome: taa.nome
      });
    });
  }

  updateAreaAtendimento(): void {
    this.service.putAreaAtendimento(this.form.value).subscribe(() => {
      alert('Area de Atendimento alterado com sucesso!');
      this.router.navigate(['/AreasAtendimento']);
    });
  }
}
