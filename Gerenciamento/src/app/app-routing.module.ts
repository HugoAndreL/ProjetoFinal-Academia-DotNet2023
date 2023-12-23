import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { RegistrarComponent } from './components/usuarios/registrar/registrar.component';
import { AlterarComponent } from './components/usuarios/alterar/alterar.component';
import { DesativarComponent } from './components/usuarios/desativar/desativar.component';

import { AuditoriaUsuarioComponent } from './components/usuarios/auditoria-usuario/auditoria-usuario.component';

import { CargosComponent } from './components/cargos/cargos.component';
import { AdicionarComponent } from './components/cargos/adicionar/adicionar.component';
import { EditarComponent } from './components/cargos/editar/editar.component';
import { RemoverComponent } from './components/cargos/remover/remover.component';

import { AuditoriaCargosComponent } from './components/cargos/auditoria-cargos/auditoria-cargos.component';

const routes: Routes = [
  {path: 'Usuarios', component: UsuariosComponent},
  {path: 'Usuarios/Registrar', component: RegistrarComponent},
  {path: 'Usuarios/Alterar/:id', component: AlterarComponent},
  {path: 'Usuarios/Desativar/:id', component: DesativarComponent},
  
  {path: 'Auditoria/Usuarios', component: AuditoriaUsuarioComponent},
  {path: 'Auditoria/Cargos', component: AuditoriaCargosComponent},

  {path: 'Cargos', component: CargosComponent},
  {path: 'Cargos/Adicionar', component: AdicionarComponent},
  {path: 'Cargos/Alterar/:id', component: EditarComponent},
  {path: 'Cargos/Desativar/:id', component: RemoverComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
