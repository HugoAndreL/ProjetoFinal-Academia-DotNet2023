import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CargosComponent } from './components/cargos/cargos.component';
import { AdicionarComponent } from './components/cargos/adicionar/adicionar.component';
import { EditarComponent } from './components/cargos/editar/editar.component';
import { ConfirmRemocaoComponent } from './components/cargos/confirm-remocao/confirm-remocao.component';
import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { RegistrarComponent } from './components/usuarios/registrar/registrar.component';


const routes: Routes = [
  {path: 'Usuarios', component: UsuariosComponent},
  {path: 'Usuarios/Registrar', component: RegistrarComponent},
  

  {path: 'Cargos', component: CargosComponent},
  {path: 'Cargos/Adicionar', component: AdicionarComponent},
  {path: 'Cargos/Alterar', component: EditarComponent},
  {path: 'Cargos/Desativar', component: ConfirmRemocaoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
