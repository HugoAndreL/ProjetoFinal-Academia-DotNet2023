import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './security/auth.guard';
   
import { UsuariosComponent } from './components/home/usuarios/usuarios.component';
import { RegistraUsuarioComponent } from './components/home/usuarios/registra-usuario/registra-usuario.component';
import { AlterarUsuarioComponent } from './components/home/usuarios/alterar-usuario/alterar-usuario.component';
import { RemoverUsuarioComponent } from './components/home/usuarios/remover-usuario/remover-usuario.component';

import { AuditoriaUsuarioComponent } from './components/home/usuarios/auditoria-usuario/auditoria-usuario.component';

import { CargosComponent } from './components/home/cargos/cargos.component';
import { AdicionarCargoComponent } from './components/home/cargos/adicionar-cargo/adicionar-cargo.component';
import { AlterarCargoComponent } from './components/home/cargos/alterar-cargo/alterar-cargo.component';
import { DesativarCargoComponent } from './components/home/cargos/desativar-cargo/desativar-cargo.component';

import { AuditoriaCargosComponent } from './components/home/cargos/auditoria-cargos/auditoria-cargos.component';

import { TipoAreaAtendimentoComponent } from './components/home/tipo-area-atendimento/tipo-area-atendimento.component';
import { AdicionarTaaComponent } from './components/home/tipo-area-atendimento/adicionar-taa/adicionar-taa.component';
import { AlterarTaaComponent } from './components/home/tipo-area-atendimento/alterar-taa/alterar-taa.component';
import { ExcluirTaaComponent } from './components/home/tipo-area-atendimento/excluir-taa/excluir-taa.component';

import { AreaAtendimentoComponent } from './components/home/area-atendimento/area-atendimento.component';
import { AdicionarAaComponent } from './components/home/area-atendimento/adicionar-aa/adicionar-aa.component';
import { AlterarAaComponent } from './components/home/area-atendimento/alterar-aa/alterar-aa.component';
import { ExcluirAaComponent } from './components/home/area-atendimento/excluir-aa/excluir-aa.component';

import { RelatoriosComponent } from './components/home/relatorios/relatorios.component';
import { AdicionarDocComponent } from './components/home/relatorios/adicionar-doc/adicionar-doc.component';

import { FuncionalidadeComponent } from './components/home/funcionalidade/funcionalidade.component';
import { AdicionarFuncComponent } from './components/home/funcionalidade/adicionar-func/adicionar-func.component';
import { AssoicarFuncComponent } from './components/home/funcionalidade/assoicar-func/assoicar-func.component';

import { SenhaComponent } from './components/home/senha/senha.component';
import { HistoricoComponent } from './components/home/senha/historico/historico.component';

import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'Login'},
  {path: 'Login', component: LoginComponent},
  {
    path: 'Home',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
      {path: 'Usuarios', component: UsuariosComponent},
      {path: 'Usuarios/Registrar', component: RegistraUsuarioComponent},
      {path: 'Usuarios/Alterar/:id', component: AlterarUsuarioComponent},
      {path: 'Usuarios/Desativar/:id', component: RemoverUsuarioComponent},
      
      {path: 'Auditoria/Usuarios', component: AuditoriaUsuarioComponent},
      {path: 'Auditoria/Cargos', component: AuditoriaCargosComponent},
    
      {path: 'Cargos', component: CargosComponent},
      {path: 'Cargos/Adicionar', component: AdicionarCargoComponent},
      {path: 'Cargos/Alterar/:id', component: AlterarCargoComponent},
      {path: 'Cargos/Desativar/:id', component: DesativarCargoComponent},
    
      {path: 'TiposAreasAtendimento', component: TipoAreaAtendimentoComponent},
      {path: 'TiposAreasAtendimento/Adicionar', component: AdicionarTaaComponent},
      {path: 'TiposAreasAtendimento/Alterar/:id', component: AlterarTaaComponent},
      {path: 'TiposAreasAtendimento/Excluir/:id', component: ExcluirTaaComponent},
    
      {path: 'AreasAtendimento', component: AreaAtendimentoComponent},
      {path: 'AreasAtendimento/Adicionar', component: AdicionarAaComponent},
      {path: 'AreasAtendimento/Alterar/:id', component: AlterarAaComponent},
      {path: 'AreasAtendimento/Desativar/:id', component: ExcluirAaComponent},
    
      {path: 'Relatorios', component: RelatoriosComponent},
      {path: 'Relatorios/Adicionar', component: AdicionarDocComponent},
    
      {path: 'Funcionalidades', component: FuncionalidadeComponent},
      {path: 'Funcionalidades/Adicionar', component: AdicionarFuncComponent},
      {path: 'Funcionalidades/Associar/:id', component: AssoicarFuncComponent},
    
      {path: 'Senhas', component: SenhaComponent},
      {path: 'Senhas/Historico', component: HistoricoComponent},
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
