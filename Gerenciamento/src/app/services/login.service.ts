import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core'; 

import { Observable, catchError, throwError } from 'rxjs';

import { Login } from '../models/login';
import { Usuario } from '../models/usuario';
import { Funcionalidade } from '../models/funcionalidade';

import { jwtDecode } from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  url = 'https://localhost:7222/api/Token';

  constructor(private http: HttpClient, private router: Router) { }

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

  postLogin(log: Login): Observable<Login> {
    return this.http.post<Login>(`${this.url}/Login`, JSON.stringify(log), this.httpOptions)
      .pipe(catchError(this.handleErr));
  }

  getUserByToken(): Observable<Usuario> {
    return this.http.get<Usuario>(`${this.url}/ConferirUsuario`)
      .pipe(catchError(this.handleErr))
  }

  getFuncsbyToken(): Observable<Funcionalidade[]> {
    return this.http.get<Funcionalidade[]>(`${this.url}/ConferirPermissoes`)
      .pipe(catchError(this.handleErr));
  }

  pacthLogin() {
    const patch: object = [
      {
        "op": "remove" ,
        "path": "/Token"
      } 
    ]
    return this.http.patch(`${this.url}/Logout`, patch, this.httpOptions)
      .pipe(catchError(this.handleErr));
  }

  ehExpirado(token: string | null): boolean {
    if (token) {
      const tokenCodificado: any = jwtDecode(token);

      return tokenCodificado.exp < Date.now() / 1000;
    }
    else return true;
  }
}