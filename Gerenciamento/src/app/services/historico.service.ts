import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, catchError, throwError } from 'rxjs';

import { Historico } from '../models/historico';

@Injectable({
  providedIn: 'root'
})
export class HistoricoService {
  url = 'https://localhost:7222/api/Historicos';

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

  getSenhas(): Observable<Historico[]> {
    return this.http.get<Historico[]>(`${this.url}/Senhas`)
      .pipe(catchError(this.handleErr));
  }
}
