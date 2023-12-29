import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { Senha } from '../models/senha';

@Injectable({
  providedIn: 'root'
})
export class SenhaService {
  private url = 'https://localhost:7222/api/Senhas';

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

  getSenhas(): Observable<Senha[]> {
    return this.http.get<Senha[]>(this.url)
      .pipe(catchError(this.handleErr));
  }

  getSenhabyId(id: number | undefined): Observable<Senha> {
    return this.http.get<Senha>(`${this.url}/Selecionar/${id}`)
      .pipe(catchError(this.handleErr));
  }
  
  postSenha(senha: Senha): Observable<Senha> {
    return this.http.post<Senha>(`${this.url}/Adicionar`, JSON.stringify(senha), this.httpOptions)
      .pipe(catchError(this.handleErr));
  }

  putSenha(senha: Senha): Observable<Senha> {
    return this.http.put<Senha>(`${this.url}/Alterar/${senha.id}`, JSON.stringify(senha), this.httpOptions)
        .pipe(catchError(this.handleErr));
  }

  deleteSenha(senha: Senha): Observable<Senha> {
    return this.http.delete<Senha>(`${this.url}/Desativar/${senha.id}`);
  }
}
