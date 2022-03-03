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
import { paradasDTO } from '../paradas/paradasDTO';
import { webResult } from '../utilidades/webResult';
import { viajeDTO, viajeFiltroDTO } from './viajaeDTO';

@Injectable({
  providedIn: 'root',
})
export class ViajesService {
  constructor(private http: HttpClient, private router: Router) {}

  private apiURL = environment.apiURL + '/viajes';

  public obtenerViaje(id: number): Observable<webResult> {
    return this.http.get<webResult>(this.apiURL + '/' + id);
  }

  public obtenerViajes(
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

  public crear(viajeDTO: viajeDTO): Observable<HttpResponse<webResult>> {
    return this.http.post<webResult>(this.apiURL, JSON.stringify(viajeDTO), {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      observe: 'response',
    });
  }

  public editar(viajeDTO: viajeDTO) {
    console.log(JSON.stringify(viajeDTO));
    return this.http.patch<webResult>(
      `${this.apiURL}/${viajeDTO.id}`,
      JSON.stringify(viajeDTO),
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        }),
        observe: 'response',
      }
    );
  }

  public eliminar(viajeDTO: viajeDTO) {
    return this.http.delete<webResult>(`${this.apiURL}?id=${viajeDTO.id}`, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      observe: 'response',
    });
  }

  public filtrarViajes(
    viajeFiltroDTO: viajeFiltroDTO,
    pagina: number,
    cantidadRegistrosAMostrar: number
  ): Observable<HttpResponse<webResult>> {
    viajeFiltroDTO.estado =
      viajeFiltroDTO.estado == -1 ? null : viajeFiltroDTO.estado;

    const tree = this.router.createUrlTree([], {
      queryParams: { ...viajeFiltroDTO, pagina, cantidadRegistrosAMostrar },
    });

    return this.http.get<webResult>(`${environment.apiURL}${tree.toString()}`, {
      observe: 'response',
    });
  }
}
