import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  HttpClient,
  HttpResponse,
  HttpParams,
  HttpHeaders,
} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { webResult } from '../utilidades/webResult';
import { clienteDTO } from './clienteDTO';

@Injectable({
  providedIn: 'root',
})
export class ClienteService {
  constructor(private http: HttpClient) {}

  private apiURL = environment.apiURL + 'clientes';
  public obtenerClientes(
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

  public crear(clienteDTO: clienteDTO): Observable<HttpResponse<webResult>> {
    return this.http.post<webResult>(this.apiURL, JSON.stringify(clienteDTO), {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      observe: 'response',
    });
  }

  public editar(clienteDTO: clienteDTO) {
    return this.http.patch<webResult>(
      `${this.apiURL}/${clienteDTO.dni}`,
      JSON.stringify(clienteDTO),
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        }),
        observe: 'response',
      }
    );
  }

  public eliminar(clienteDTO: clienteDTO) {
    console.log(clienteDTO);
    return this.http.delete<webResult>(`${this.apiURL}?id=${clienteDTO.dni}`, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      observe: 'response',
    });
  }
}
