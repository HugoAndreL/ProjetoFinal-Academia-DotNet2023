import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { LoginService } from './services/login.service';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { LoginComponent } from './components/login/login.component';

import { HomeComponent } from './components/home/home.component';

import { HeaderComponent } from './components/header/header.component';
import { NavComponent } from './components/home/nav/nav.component';

import { CargosComponent } from './components/home/cargos/cargos.component';
import { AdicionarCargoComponent } from './components/home/cargos/adicionar-cargo/adicionar-cargo.component';
import { AlterarCargoComponent } from './components/home/cargos/alterar-cargo/alterar-cargo.component';
import { DesativarCargoComponent } from './components/home/cargos/desativar-cargo/desativar-cargo.component';

import { AuditoriaCargosComponent } from './components/home/cargos/auditoria-cargos/auditoria-cargos.component';

import { UsuariosComponent } from './components/home/usuarios/usuarios.component';
import { RegistraUsuarioComponent } from './components/home/usuarios/registra-usuario/registra-usuario.component';
import { AlterarUsuarioComponent } from './components/home/usuarios/alterar-usuario/alterar-usuario.component';
import { RemoverUsuarioComponent } from './components/home/usuarios/remover-usuario/remover-usuario.component';

import { AuditoriaUsuarioComponent } from './components/home/usuarios/auditoria-usuario/auditoria-usuario.component';

import { AreaAtendimentoComponent } from './components/home/area-atendimento/area-atendimento.component';
import { AdicionarAaComponent } from './components/home/area-atendimento/adicionar-aa/adicionar-aa.component';
import { AlterarAaComponent } from './components/home/area-atendimento/alterar-aa/alterar-aa.component';
import { ExcluirAaComponent } from './components/home/area-atendimento/excluir-aa/excluir-aa.component';

import { TipoAreaAtendimentoComponent } from './components/home/tipo-area-atendimento/tipo-area-atendimento.component';
import { AdicionarTaaComponent } from './components/home/tipo-area-atendimento/adicionar-taa/adicionar-taa.component';
import { AlterarTaaComponent } from './components/home/tipo-area-atendimento/alterar-taa/alterar-taa.component';
import { ExcluirTaaComponent } from './components/home/tipo-area-atendimento/excluir-taa/excluir-taa.component';

import { RelatoriosComponent } from './components/home/relatorios/relatorios.component';
import { AdicionarDocComponent } from './components/home/relatorios/adicionar-doc/adicionar-doc.component';

import { FuncionalidadeComponent } from './components/home/funcionalidade/funcionalidade.component';
import { AdicionarFuncComponent } from './components/home/funcionalidade/adicionar-func/adicionar-func.component';
import { AssoicarFuncComponent } from './components/home/funcionalidade/assoicar-func/assoicar-func.component';

import { SenhaComponent } from './components/home/senha/senha.component';
import { HistoricoComponent } from './components/home/senha/historico/historico.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    NavComponent,
    
    LoginComponent,
    
    HomeComponent,
    
    CargosComponent,
    AdicionarCargoComponent,
    AlterarCargoComponent,
    DesativarCargoComponent,

    AuditoriaCargosComponent,

    UsuariosComponent,
    RegistraUsuarioComponent,
    AlterarUsuarioComponent,
    RemoverUsuarioComponent,

    AuditoriaUsuarioComponent,
    
    AreaAtendimentoComponent,
    AdicionarAaComponent,
    AlterarAaComponent,
    ExcluirAaComponent,
    
    TipoAreaAtendimentoComponent,
    AdicionarTaaComponent,
    AlterarTaaComponent,
    ExcluirTaaComponent,

    RelatoriosComponent,
    AdicionarDocComponent,
    FuncionalidadeComponent,
    AdicionarFuncComponent,
    AssoicarFuncComponent,

    SenhaComponent,
    HistoricoComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FontAwesomeModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    LoginService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }