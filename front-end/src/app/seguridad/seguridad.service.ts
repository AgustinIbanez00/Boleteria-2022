import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SeguridadService {
  constructor(private router: Router) { }

  private apiURL = environment.apiURL + 'cuentas';
  private readonly llaveToken = 'token';
  private readonly llaveNombre = 'nombre';
  // private readonly llaveExpiracion = 'token-expiracion';
  private readonly campoRol = 'role';

  estaLogueado(): boolean {
    const token = localStorage.getItem(this.llaveToken);
    if (!token) {
      return false;
    }

    // const expiracion = localStorage.getItem(this.llaveExpiracion);
    // const expiracionFecha = new Date(expiracion);

    // if (expiracionFecha <= new Date()) {
    //   this.logout();
    //   return false;
    // }
    return true;
  }
  obtenerToken() {
    return localStorage.getItem(this.llaveToken);
  }
  guardarToken(token: string) {
    localStorage.setItem(this.llaveToken, token);
    this.router.navigate(['/']);
  }
  logout() {
    localStorage.removeItem(this.llaveToken);
    // localStorage.removeItem(this.llaveExpiracion);
    this.router.navigate(['/']);
  }

  obtenerRol(): string {
    return this.obtenerCapmpoJWT(this.campoRol);
  }

  obtenerCapmpoJWT(campo: string): string {
    const token = localStorage.getItem(this.llaveToken);
    if (!token) {
      return '';
    }
    var dataToken = JSON.parse(atob(token.split('.')[1]));
    return dataToken[campo];
  }
}
