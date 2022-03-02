import {
  HttpClient,
  HttpResponse,
  HttpParams,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { webResult } from '../utilidades/webResult';
import { paradasDTO, paradasFiltroDTO } from './paradasDTO';

@Injectable({
  providedIn: 'root',
})
export class ParadasService {
  constructor(private http: HttpClient, private router: Router) {}

  private apiURL = environment.apiURL + '/paradas';

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
    console.log('crear 2');
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

  public eliminar(paradaDTO: paradasDTO) {
    return this.http.delete<webResult>(`${this.apiURL}?id=${paradaDTO.id}`, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      observe: 'response',
    });
  }

  public filtrarParadas(
    paradasFiltroDTO: paradasFiltroDTO,
    pagina: number,
    cantidadRegistrosAMostrar: number
  ): Observable<HttpResponse<webResult>> {
    paradasFiltroDTO.estado =
      paradasFiltroDTO.estado == -1 ? null : paradasFiltroDTO.estado;

    const tree = this.router.createUrlTree([], {
      queryParams: { ...paradasFiltroDTO, pagina, cantidadRegistrosAMostrar },
    });

    console.log(`${environment.apiURL}${tree.toString()}`);

    return this.http.get<webResult>(`${environment.apiURL}${tree.toString()}`, {
      observe: 'response',
    });
  }
}
