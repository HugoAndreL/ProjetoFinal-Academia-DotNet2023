import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';

import { Observable, catchError, throwError } from 'rxjs';

import { Cargo } from '../models/cargo';

@Injectable({
  providedIn: 'root'
})
export class CargoService {
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

  getCargos(): Observable<Cargo[]> {
    return this.http.get<Cargo[]>(this.url)
      .pipe(catchError(this.handleErr));
  }

  getCargobyId(id: number | undefined): Observable<Cargo> {
    return this.http.get<Cargo>(`${this.url}/Selecionar/${id}`)
      .pipe(catchError(this.handleErr));
  }
  
  postCargo(cargo: Cargo): Observable<Cargo> {
    return this.http.post<Cargo>(`${this.url}/Adicionar`, JSON.stringify(cargo), this.httpOptions)
      .pipe(catchError(this.handleErr));
  }

  putCargo(cargo: Cargo): Observable<Cargo> {
    return this.http.put<Cargo>(`${this.url}/Alterar/${cargo.id}`, JSON.stringify(cargo), this.httpOptions)
        .pipe(catchError(this.handleErr));
  }

  deleteCargo(cargo: Cargo): Observable<Cargo> {
    return this.http.delete<Cargo>(`${this.url}/Desativar/${cargo.id}`);
  }
}
