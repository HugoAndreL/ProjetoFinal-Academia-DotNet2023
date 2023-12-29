import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HeaderComponent } from './components/header/header.component';
import { NavComponent } from './components/nav/nav.component';

import { UsuarioService } from './services/usuario.service';
import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { RegistraUsuarioComponent } from './components/usuarios/registra-usuario/registra-usuario.component';
import { AlterarUsuarioComponent } from './components/usuarios/alterar-usuario/alterar-usuario.component';
import { RemoverUsuarioComponent } from './components/usuarios/remover-usuario/remover-usuario.component';

import { AuditoriaUsuarioComponent } from './components/usuarios/auditoria-usuario/auditoria-usuario.component';

import { CargoService } from './services/cargo.service';
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

import { FuncionalidadeComponent } from './components/funcionalidade/funcionalidade.component';
import { AdicionarFuncComponent } from './components/funcionalidade/adicionar-func/adicionar-func.component';
import { AssoicarFuncComponent } from './components/funcionalidade/assoicar-func/assoicar-func.component';

import { TipoAreaAtendimentoService } from './services/tipo-area-atendimento.service';
import { AreaAtendimentoService } from './services/area-atendimento.service';
import { RelatorioService } from './services/relatorio.service';
import { AdicionarDocComponent } from './components/relatorios/adicionar-doc/adicionar-doc.component';
import { FuncionalidadeService } from './services/funcionalidade.service';

import { SenhaComponent } from './components/senha/senha.component';

import { LoginComponent } from './components/login/login.component';
import { LoginService } from './services/login.service';
import { SenhaService } from './services/senha.service';
import { AuditoriaService } from './services/auditoria.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    NavComponent,
    
    LoginComponent,
    
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
    provideClientHydration(),
    AreaAtendimentoService,
    AuditoriaService,
    CargoService,
    FuncionalidadeService,
    LoginService,
    RelatorioService,
    SenhaService,
    TipoAreaAtendimentoService,
    UsuarioService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }