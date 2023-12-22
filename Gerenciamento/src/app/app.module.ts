import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { NavComponent } from './components/nav/nav.component';
import { CargosComponent } from './components/cargos/cargos.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CargoService } from './services/cargo.service';
import { UsuarioService } from './services/usuario.service';
import { EditarComponent } from './components/cargos/editar/editar.component';
import { AdicionarComponent } from './components/cargos/adicionar/adicionar.component';
import { ConfirmRemocaoComponent } from './components/cargos/confirm-remocao/confirm-remocao.component';
import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { RegistrarComponent } from './components/usuarios/registrar/registrar.component';
import { AlterarComponent } from './components/usuarios/alterar/alterar.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    NavComponent,
    CargosComponent,
    EditarComponent,
    AdicionarComponent,
    ConfirmRemocaoComponent,
    UsuariosComponent,
    RegistrarComponent,
    AlterarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FontAwesomeModule,
    FormsModule
  ],
  providers: [
    provideClientHydration(),
    CargoService,
    UsuarioService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
