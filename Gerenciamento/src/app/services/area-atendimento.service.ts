import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, catchError, throwError } from 'rxjs';

import { AreaAtendimento } from '../models/area-atendimento';

@Injectable({
  providedIn: 'root'
})
export class AreaAtendimentoService {
  private url = 'https://localhost:7222/api/Cargos';

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

  getAreaAtendimentos(): Observable<AreaAtendimento[]> {
    return this.http.get<AreaAtendimento[]>(this.url)
      .pipe(catchError(this.handleErr));
  }

  getAreaAtendimentobyId(id: number | undefined): Observable<AreaAtendimento> {
    return this.http.get<AreaAtendimento>(`${this.url}/Selecionar/${id}`)
      .pipe(catchError(this.handleErr));
  }
  
  postAreaAtendimento(aa: AreaAtendimento): Observable<AreaAtendimento> {
    return this.http.post<AreaAtendimento>(`${this.url}/Adicionar`, JSON.stringify(aa), this.httpOptions)
      .pipe(catchError(this.handleErr));
  }

  putAreaAtendimento(aa: AreaAtendimento): Observable<AreaAtendimento> {
    return this.http.put<AreaAtendimento>(`${this.url}/Alterar/${aa.id}`, JSON.stringify(aa), this.httpOptions)
        .pipe(catchError(this.handleErr));
  }

  deleteAreaAtendimento(aa: AreaAtendimento): Observable<AreaAtendimento> {
    return this.http.delete<AreaAtendimento>(`${this.url}/Desativar/${aa.id}`);
  }
}
