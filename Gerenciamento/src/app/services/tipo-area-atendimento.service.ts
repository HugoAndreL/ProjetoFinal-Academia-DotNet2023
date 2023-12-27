import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, catchError, throwError } from 'rxjs';

import { TipoAreaAtendimento } from '../models/tipo-area-atendimento';

@Injectable({
  providedIn: 'root'
})
export class TipoAreaAtendimentoService {
  private url = 'https://localhost:7222/api/TiposAreasAtendimento';

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

  getTiposAreasAtendimento(): Observable<TipoAreaAtendimento[]> {
    return this.http.get<TipoAreaAtendimento[]>(this.url)
      .pipe(catchError(this.handleErr));
  }

  getTipoAreaAtendimentobyId(id: number | undefined): Observable<TipoAreaAtendimento> {
    return this.http.get<TipoAreaAtendimento>(`${this.url}/Selecionar/${id}`)
      .pipe(catchError(this.handleErr));
  }
  
  postTipoAreaAtendimento(taa: TipoAreaAtendimento): Observable<TipoAreaAtendimento> {
    return this.http.post<TipoAreaAtendimento>(`${this.url}/Adicionar`, JSON.stringify(taa), this.httpOptions)
      .pipe(catchError(this.handleErr));
  }

  putTipoAreaAtendimento(taa: TipoAreaAtendimento): Observable<TipoAreaAtendimento> {
    return this.http.put<TipoAreaAtendimento>(`${this.url}/Alterar/${taa.id}`, JSON.stringify(taa), this.httpOptions)
        .pipe(catchError(this.handleErr));
  }

  deleteTipoAreaAtendimento(taa: TipoAreaAtendimento): Observable<TipoAreaAtendimento> {
    return this.http.delete<TipoAreaAtendimento>(`${this.url}/Desativar/${taa.id}`);
  }
}
