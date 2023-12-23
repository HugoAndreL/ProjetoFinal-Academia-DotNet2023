import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';

import { Observable, catchError, throwError } from 'rxjs';

import { AuditoriaUsuarios } from '../models/auditoria-usuarios';
import { AuditoriaCargos } from '../models/auditoria-cargos';

@Injectable({
  providedIn: 'root'
})
export class AuditoriaService {
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

  getUsuarios(): Observable<AuditoriaUsuarios[]> {
    return this.http.get<AuditoriaUsuarios[]>(`${this.url}/Usuarios`)
      .pipe(catchError(this.handleErr));
  }

  getCargos(): Observable<AuditoriaCargos[]> {
    return this.http.get<AuditoriaCargos[]>(`${this.url}/Cargos`)
  }
}
