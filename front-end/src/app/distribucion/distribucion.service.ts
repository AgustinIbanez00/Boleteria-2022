import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { webResult } from '../utilidades/webResult';
import { distribucionDTO, DistribucionDTO } from './distribucionDTO';

@Injectable({
  providedIn: 'root',
})
export class DistribucionService {
  private apiURL = environment.apiURL + '/distribuciones';
  constructor(private http: HttpClient) {}

  obtenerDistribucion(id: number): Observable<webResult> {
    return this.http.get<webResult>(this.apiURL + '/' + id);
  }

  obtenerDistribuciones(): Observable<webResult> {
    return this.http.get<webResult>(this.apiURL);
  }

  guardarDistribucion(distribucion: DistribucionDTO): Observable<webResult> {
    return this.http.post<webResult>(this.apiURL, distribucion);
  }

  obtenerDistribucionesViaje(): Observable<HttpResponse<webResult>> {
    return this.http.get<webResult>(`${this.apiURL}`, {
      observe: 'response',
    });
  }

  public eliminar(distribucionDTO: distribucionDTO) {
    return this.http.delete<webResult>(
      `${this.apiURL}?id=${distribucionDTO.id}`,
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        }),
        observe: 'response',
      }
    );
  }
}
