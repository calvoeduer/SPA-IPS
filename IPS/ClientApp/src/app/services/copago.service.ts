import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, tap } from "rxjs/operators";
import { Copago } from '../models/copago';
import { HttpErrorHandlerService } from '../@base/http-error-handler.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json',
    'Authorization' : 'my-auth-token'  
  })
};

@Injectable({
  providedIn: 'root'
})
export class CopagoService {

  private readonly copagoUrl = 'api/CoPago';

  constructor(private http: HttpClient, private httpError: HttpErrorHandlerService) { }

  get(): Observable<Copago[]> {
    return this.http.get<Copago[]>(this.copagoUrl + '/Liquidaciones')
      .pipe(
        tap(_ => this.httpError.log('Datos recibidos')),
        catchError(this.httpError.handleError<Copago[]>('getCopagos', []))
      );
  }

  post(copago: Copago): Observable<Copago> {
    return this.http.post<Copago>(this.copagoUrl + '/Insert', copago, httpOptions)
      .pipe(
        tap(_ => this.httpError.log('Datos enviados')),
        catchError(this.httpError.handleError<Copago>('postCopago', null))
      );
  } 
}
