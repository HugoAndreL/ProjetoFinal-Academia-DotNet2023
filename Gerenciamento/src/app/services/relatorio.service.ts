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

  getRelatorios(): Observable<Relatorio[]> {
    return this.http.get<Relatorio[]>(this.url)
      .pipe(catchError(this.handleErr));
  }

  // getAreaAtendimentobyId(id: number | undefined): Observable<AreaAtendimento> {
  //   return this.http.get<AreaAtendimento>(`${this.url}/Selecionar/${id}`)
  //     .pipe(catchError(this.handleErr));
  // }
  
  // postAreaAtendimento(aa: AreaAtendimento): Observable<AreaAtendimento> {
  //   return this.http.post<AreaAtendimento>(`${this.url}/Adicionar`, JSON.stringify(aa), this.httpOptions)
  //     .pipe(catchError(this.handleErr));
  // }
}
