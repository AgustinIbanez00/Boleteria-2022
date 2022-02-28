import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { webResult } from 'src/app/utilidades/webResult';

import { environment } from 'src/environments/environment.prod';
import { loginDTO, registroDTO } from './usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  private apiURL = environment.apiURL + 'usuario';
  constructor(private http: HttpClient) { }

  crearUsuario(usuario: registroDTO): Observable<webResult> {
    return this.http.post<webResult>(this.apiURL, usuario);
  }

  login(login: loginDTO): Observable<webResult> {
    return this.http.post<webResult>(this.apiURL + "/login", login)
  }
  obtenerUsuario(email: string): Observable<webResult> {
    return this.http.get<webResult>(this.apiURL + "/me");
  }
}
