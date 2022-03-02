import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { webResult } from '../utilidades/webResult';
import { Distribucion } from './distribucionDTO';

@Injectable({
  providedIn: 'root'
})
export class DistribucionService {

  private apiURL = environment.apiURL + 'distribuciones';
  constructor(private http: HttpClient) { }

  guardarDistribucion(distribucion: Distribucion): Observable<webResult> {
    return this.http.post<webResult>(this.apiURL, distribucion);
  }
}
