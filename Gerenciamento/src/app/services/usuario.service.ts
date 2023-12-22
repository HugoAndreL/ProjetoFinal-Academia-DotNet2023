import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';

import { Observable, catchError, retry, throwError } from 'rxjs';

import { Usuario } from '../models/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  url = 'https://localhost:7222/api/Usuarios';

  constructor(private httpClient: HttpClient) {}

  httpOptions = {
    headers: new HttpHeaders ({ 'content-type': 'application/json'})
  }

  handleErr(err: HttpErrorResponse) {
    let errMsg = '';
    if (err.error instanceof ErrorEvent)
      errMsg = err.error.message;
    else errMsg = `Código do erro: ${err.status}, \n\t
                  mensagem: ${err.message}`;
    return throwError(errMsg);
  }

  getUsuarios(): Observable<Usuario[]> {
    return this.httpClient.get<Usuario[]>(this.url)
      .pipe(retry(2), catchError(this.handleErr));
  }

  postUsuario(user: Usuario): Observable<Usuario> {
    return this.httpClient.post<Usuario>(`${this.url}/Cadastrar`, JSON.stringify(user), this.httpOptions)
      .pipe(retry(2), catchError(this.handleErr));
  }
}
