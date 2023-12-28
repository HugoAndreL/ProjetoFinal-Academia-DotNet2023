import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, catchError, throwError } from 'rxjs';

import { Funcionalidade } from '../models/funcionalidade';

@Injectable({
  providedIn: 'root'
})
export class FuncionalidadeService {
  private url = 'https://localhost:7222/api/Funcionalidades';

  constructor(private http: HttpClient) {}

  httpOptions = {
    headers: new HttpHeaders ({ 'content-type': 'application/json' })
  }

  httpPatch = {
    headers: new HttpHeaders ({ "content-type": 'application/json-patch+json'})
  }

  handleErr(err: HttpErrorResponse) {
    let errMsg = '';
    if (err.error instanceof ErrorEvent)
      errMsg = err.error.message;
    else errMsg = `Código do erro: ${err.status}, \n\t
                  mensagem: ${err.message}`;
    return throwError(errMsg);
  }

  getFuncionalidade(): Observable<Funcionalidade[]> {
    return this.http.get<Funcionalidade[]>(this.url)
      .pipe(catchError(this.handleErr));
  }

  getFuncionalidadebyId(id: number | undefined): Observable<Funcionalidade> {
    return this.http.get<Funcionalidade>(`${this.url}/Selecionar/${id}`)
      .pipe(catchError(this.handleErr));
  }
  
  postFuncionalidade(func: Funcionalidade): Observable<Funcionalidade> {
    return this.http.post<Funcionalidade>(`${this.url}/Adicionar`, JSON.stringify(func), this.httpOptions)
      .pipe(catchError(this.handleErr));
  }

  patchFunciolidade(func: Funcionalidade): Observable<Funcionalidade> {
    const httpPacth = {
      headers: new HttpHeaders ({ 'content-type': 'application/json-patch+json' })
    }
    let json: object = [ 
      {
        "op": "replace",
        "path": "/cargoId",
        "value": func.cargoId
      } 
    ]
    return this.http.patch<Funcionalidade>(`${this.url}/Associar/${func.id}`, json, this.httpPatch)
      .pipe(catchError(this.handleErr));
  }
}
