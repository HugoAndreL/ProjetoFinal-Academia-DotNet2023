import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, catchError, throwError } from 'rxjs';

import { Senha } from '../models/senha';
import { Historico } from '../models/historico';

@Injectable({
  providedIn: 'root'
})
export class SenhaService {
  private url = 'https://localhost:7222/api/Senhas';

  constructor(private http: HttpClient) {}

  httpOptions = {
    headers: new HttpHeaders ({ 'content-type': 'application/json-patch+json'})
  }

  handleErr(err: HttpErrorResponse) {
    let errMsg = '';
    if (err.error instanceof ErrorEvent)
      errMsg = err.error.message;
    else errMsg = `Código do erro: ${err.status}, \n\t
                  mensagem: ${err.message}`;
    return throwError(errMsg);
  }

  getSenhas(): Observable<Senha[]> {
    return this.http.get<Senha[]>(this.url)
      .pipe(catchError(this.handleErr));
  }

  getSenha(): Observable<Senha> {
    return this.http.get<Senha>(`${this.url}/Proxima`)
      .pipe(catchError(this.handleErr));
  }

  getHistorico(): Observable<Historico> {
    return this.http.get<Historico>(`${this.url}/Rechamar`)
      .pipe(catchError(this.handleErr))
  }

  postSenha(senha: Senha): Observable<Senha> {
    return this.http.post<Senha>(`${this.url}/Gerar`, JSON.stringify(senha), this.httpOptions)
      .pipe(catchError(this.handleErr));
  }

  patchSenha(senha: Senha): Observable<Senha> {
    return this.http.patch<Senha>(`${this.url}/Ordem/${senha.id}`, JSON.stringify(senha), this.httpOptions)
        .pipe(catchError(this.handleErr));
  }

  deleteSenha(senha: Senha): Observable<Senha> {
    return this.http.delete<Senha>(`${this.url}/Cancelar/${senha.id}`);
  }
}