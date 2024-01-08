import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, throwError, catchError } from 'rxjs';

import { Relatorio } from '../models/relatorio';

@Injectable({
  providedIn: 'root'
})
export class RelatorioService {
  private url = 'https://localhost:7222/api/Relatorios';

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

  getRelatorios(): Observable<Relatorio[]> {
    return this.http.get<Relatorio[]>(this.url)
      .pipe(catchError(this.handleErr));
  }

  getRelatoriobyId(id: number | undefined): Observable<Relatorio> {
    return this.http.get<Relatorio>(`${this.url}/Selecionar/${id}`)
      .pipe(catchError(this.handleErr));
  }
  
  postRelatorio(rel: Relatorio): Observable<Relatorio> {
    return this.http.post<Relatorio>(`${this.url}/Adicionar`, JSON.stringify(rel), this.httpOptions)
      .pipe(catchError(this.handleErr));
  }

  public getCsv(rel: Relatorio) {
    return this.http.get<Relatorio>(`${this.url}/${rel.id}`)
        .pipe(catchError(this.handleErr));
  }
}