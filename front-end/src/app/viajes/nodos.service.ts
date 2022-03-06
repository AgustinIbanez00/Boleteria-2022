import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { webResult } from '../utilidades/webResult';
import { conexionDTO } from './viajaeDTO';

@Injectable({
  providedIn: 'root',
})
export class NodosService {
  constructor(private http: HttpClient) {}

  private apiURL = environment.apiURL + '/nodos';

  public crear(conexionDTO: conexionDTO): Observable<HttpResponse<webResult>> {
    return this.http.post<webResult>(this.apiURL, JSON.stringify(conexionDTO), {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      observe: 'response',
    });
  }
}
