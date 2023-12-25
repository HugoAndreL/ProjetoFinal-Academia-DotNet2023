import { Component } from '@angular/core';
import { AreaAtendimento } from '../../../models/area-atendimento';
import { ActivatedRoute, Router } from '@angular/router';
import { AreaAtendimentoService } from '../../../services/area-atendimento.service';

@Component({
  selector: 'app-excluir-aa',
  templateUrl: './excluir-aa.component.html',
  styleUrl: './excluir-aa.component.scss'
})
export class ExcluirAaComponent {
  aa = {} as AreaAtendimento;
  
  constructor(private route: ActivatedRoute, private router: Router, private service: AreaAtendimentoService) {}
  
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.service.getAreaAtendimentobyId(parseInt(id!)).subscribe((aa) => {
      this.aa = aa;
    });
  }

  excluirTaa() {
    this.service.deleteAreaAtendimento(this.aa).subscribe(() => {
      alert(`${this.aa.nome} deletado com sucesso`);
      this.router.navigate(['/AreasAtendimento']);
    })
  }
}
