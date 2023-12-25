import { Component } from '@angular/core';
import { AreaAtendimento } from '../../../models/area-atendimento';
import { faPlus, faXmark } from '@fortawesome/free-solid-svg-icons';
import { AreaAtendimentoService } from '../../../services/area-atendimento.service';
import { Router } from '@angular/router';

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
        console.log(this.aa);
        alert('Area de Atendimento cadastrado com sucesso!');
        this.router.navigate(['/AreasAtendimento']);
      });
  }
}
