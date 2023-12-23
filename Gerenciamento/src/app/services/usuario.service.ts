import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';

import { Observable, catchError, retry, throwError } from 'rxjs';

import { Usuario } from '../models/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  url = 'https://localhost:7222/api/Usuarios';

  constructor(private http: HttpClient) {}

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
    return this.http.get<Usuario[]>(this.url)
      .pipe(catchError(this.handleErr));
  }

  getCargobyId(id: number | undefined): Observable<Usuario> {
    return this.http.get<Usuario>(`${this.url}/Selecionar/${id}`)
      .pipe(catchError(this.handleErr));
  }

  postUsuario(user: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(`${this.url}/Cadastrar`, JSON.stringify(user), this.httpOptions)
      .pipe(catchError(this.handleErr));
  }

  putUsuario(user: Usuario): Observable<Usuario> {
    return this.http.put<Usuario>(`${this.url}/Editar/${user.id}`, JSON.stringify(user), this.httpOptions)
        .pipe(catchError(this.handleErr));
  }

  deleteUsuario(user: Usuario): Observable<Usuario> {
    return this.http.delete<Usuario>(`${this.url}/Desativar/${user.id}`)
      .pipe(catchError(this.handleErr))
  }
}
