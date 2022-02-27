import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SeguridadService } from '../seguridad/seguridad.service';
import { webResult } from '../utilidades/listado-generico/weResult';

@Injectable({
  providedIn: 'root',
})
export class ParadasService {
  constructor(
    private http: HttpClient,
    private seguridadService: SeguridadService
  ) {}

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
}
