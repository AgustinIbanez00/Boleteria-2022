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
// import { SeguridadService } from '../seguridad/seguridad.service';
import { paradasDTO } from './paradasDTO';

@Injectable({
  providedIn: 'root',
})
export class ParadasService {
  constructor(private http: HttpClient) { }

  private apiURL = environment.apiURL + 'paradas';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

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

  public crear(paradaDTO: paradasDTO): Observable<webResult> {
    return this.http.post<webResult>(
      this.apiURL,
      JSON.stringify(paradaDTO),
      this.httpOptions
    );
  }
}
