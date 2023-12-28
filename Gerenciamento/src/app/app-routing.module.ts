import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './components/login/login.component';
   
import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { RegistraUsuarioComponent } from './components/usuarios/registra-usuario/registra-usuario.component';
import { AlterarUsuarioComponent } from './components/usuarios/alterar-usuario/alterar-usuario.component';
import { RemoverUsuarioComponent } from './components/usuarios/remover-usuario/remover-usuario.component';

import { AuditoriaUsuarioComponent } from './components/usuarios/auditoria-usuario/auditoria-usuario.component';

import { CargosComponent } from './components/cargos/cargos.component';
import { AdicionarCargoComponent } from './components/cargos/adicionar-cargo/adicionar-cargo.component';
import { AlterarCargoComponent } from './components/cargos/alterar-cargo/alterar-cargo.component';
import { DesativarCargoComponent } from './components/cargos/desativar-cargo/desativar-cargo.component';

import { AuditoriaCargosComponent } from './components/cargos/auditoria-cargos/auditoria-cargos.component';

import { TipoAreaAtendimentoComponent } from './components/tipo-area-atendimento/tipo-area-atendimento.component';
import { AdicionarTaaComponent } from './components/tipo-area-atendimento/adicionar-taa/adicionar-taa.component';
import { AlterarTaaComponent } from './components/tipo-area-atendimento/alterar-taa/alterar-taa.component';
import { ExcluirTaaComponent } from './components/tipo-area-atendimento/excluir-taa/excluir-taa.component';

import { AreaAtendimentoComponent } from './components/area-atendimento/area-atendimento.component';
import { AdicionarAaComponent } from './components/area-atendimento/adicionar-aa/adicionar-aa.component';
import { AlterarAaComponent } from './components/area-atendimento/alterar-aa/alterar-aa.component';
import { ExcluirAaComponent } from './components/area-atendimento/excluir-aa/excluir-aa.component';

import { RelatoriosComponent } from './components/relatorios/relatorios.component';
import { AdicionarDocComponent } from './components/relatorios/adicionar-doc/adicionar-doc.component';

import { FuncionalidadeComponent } from './components/funcionalidade/funcionalidade.component';
import { AdicionarFuncComponent } from './components/funcionalidade/adicionar-func/adicionar-func.component';
import { AssoicarFuncComponent } from './components/funcionalidade/assoicar-func/assoicar-func.component';

const routes: Routes = [
  {path: 'Login', component: LoginComponent},

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
  {path: 'Funcionalidades/Associar/:id', component: AssoicarFuncComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
