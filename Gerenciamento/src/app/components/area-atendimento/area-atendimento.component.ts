import { Component } from '@angular/core';
import { AreaAtendimento } from '../../models/area-atendimento';
import { faPenToSquare, faPlus, faTrashArrowUp } from '@fortawesome/free-solid-svg-icons';
import { AreaAtendimentoService } from '../../services/area-atendimento.service';

@Component({
  selector: 'app-area-atendimento',
  templateUrl: './area-atendimento.component.html',
  styleUrl: './area-atendimento.component.scss'
})
export class AreaAtendimentoComponent {
  areasAtendimento: AreaAtendimento[] = [];

  icEdit = faPenToSquare;
  icDesativar = faTrashArrowUp;
  icAdd = faPlus;

  constructor(private service: AreaAtendimentoService) {}

  ngOnInit() {
    this.readAreaAtendimentos();
  }

  readAreaAtendimentos() {
    this.service.getAreaAtendimentos().subscribe((aa: AreaAtendimento[]) => {
      this.areasAtendimento = aa;
    });
  }
}
