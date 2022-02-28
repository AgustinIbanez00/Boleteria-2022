import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { webResult } from 'src/app/utilidades/webResult';

import { environment } from 'src/environments/environment.prod';
import { registroDTO } from './registro';

@Injectable({
  providedIn: 'root'
})
export class RegistroService {
  private apiURL = environment.apiURL + 'usuario';
  constructor(private http: HttpClient) { }

  crearUsuario(usuario: registroDTO): Observable<webResult> {
    return this.http.post<webResult>(this.apiURL, usuario);
  }
}
