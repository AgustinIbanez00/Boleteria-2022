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
import { clienteDTO, clienteFiltroDTO } from './clienteDTO';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class ClienteService {
  constructor(private http: HttpClient, private router: Router) {}

  private apiURL = environment.apiURL;
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

    const tree = this.router.createUrlTree([], {
      queryParams: { pagina, cantidadRegistrosAMostrar },
    });

    return this.http.get<webResult>(`${this.apiURL}${tree.toString()}`, {
      observe: 'response',
      params,
    });
  }

  public crear(clienteDTO: clienteDTO): Observable<HttpResponse<webResult>> {
    return this.http.post<webResult>(
      this.apiURL + '/clientes',

      JSON.stringify(clienteDTO),
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        }),
        observe: 'response',
      }
    );
  }

  public editar(clienteDTO: clienteDTO) {
    return this.http.patch<webResult>(
      `${this.apiURL}/clientes/${clienteDTO.dni}`,
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
    return this.http.delete<webResult>(
      `${this.apiURL}/clientes/?id=${clienteDTO.dni}`,
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        }),
        observe: 'response',
      }
    );
  }

  public filtrarClientes(
    clienteFiltroDTO: clienteFiltroDTO,
    pagina: number,
    cantidadRegistrosAMostrar: number
  ): Observable<HttpResponse<webResult>> {
    clienteFiltroDTO.estado =
      clienteFiltroDTO.estado == -1 ? null : clienteFiltroDTO.estado;

    const tree = this.router.createUrlTree([], {
      queryParams: { ...clienteFiltroDTO, pagina, cantidadRegistrosAMostrar },
    });

    return this.http.get<webResult>(`${environment.apiURL}${tree.toString()}`, {
      observe: 'response',
    });
  }
}
