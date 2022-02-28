import {
  HttpClient,
  HttpResponse,
  HttpParams,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { webResult } from '../utilidades/webResult';
import { paradasDTO } from './paradasDTO';

@Injectable({
  providedIn: 'root',
})
export class ParadasService {
  constructor(private http: HttpClient) {}

  private apiURL = environment.apiURL + 'paradas';

  public obtenerParadas(
    pagina: number,
    cantidadRegistrosAMostrar: number
  ): Observable<HttpResponse<webResult>> {
    let params = new HttpParams();
    params = params.append('pagina', pagina.toString());
    params = params.append(
      'recordsPorPagina',
      cantidadRegistrosAMostrar.toString()
    );

    return this.http.get<webResult>(`${this.apiURL}`, {
      observe: 'response',
      params,
    });
  }

  public crear(paradaDTO: paradasDTO): Observable<HttpResponse<webResult>> {
    return this.http.post<webResult>(this.apiURL, JSON.stringify(paradaDTO), {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      observe: 'response',
    });
  }

  public editar(paradaDTO: paradasDTO) {
    return this.http.patch<webResult>(
      `${this.apiURL}/${paradaDTO.id}`,
      JSON.stringify(paradaDTO),
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        }),
        observe: 'response',
      }
    );
  }
}
