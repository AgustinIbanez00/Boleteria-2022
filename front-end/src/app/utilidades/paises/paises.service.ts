import { HttpClient, HttpResponse, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { webResult } from '../webResult';

@Injectable({
  providedIn: 'root',
})
export class PaisesService {
  constructor(private http: HttpClient, private router: Router) {}

  private apiURL = environment.apiURL;
  public obtenerPaises(
    nombrePais: string
  ): Observable<HttpResponse<webResult>> {
    return this.http.get<webResult>(
      `${this.apiURL}/paises?nombre=${nombrePais}`,
      {
        observe: 'response',
      }
    );
  }

  public obtenerProvincias(
    idPais: number
  ): Observable<HttpResponse<webResult>> {
    return this.http.get<webResult>(
      `${this.apiURL}/paises/${idPais}/provincias`,
      {
        observe: 'response',
      }
    );
  }
}
