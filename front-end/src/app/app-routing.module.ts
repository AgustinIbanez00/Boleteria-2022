import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EsAdminGuard } from './es-admin.guard';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { IndiceParadasComponent } from './paradas/indice-paradas/indice-paradas.component';
import { LoginComponent } from './seguridad/login/login.component';
import { RegistroComponent } from './seguridad/registro/registro.component';
import { IndiceDistribucionComponent } from './distribucion/indice-distribucion/indice-distribucion.component';
import { CrearDistribucionComponent } from './distribucion/crear-distribucion/crear-distribucion.component';
import { IndiceClienteComponent } from './cliente/indice-cliente/indice-cliente.component';
import { IndiceViajesComponent } from './viajes/indice-viajes/indice-viajes.component';
import { CrearViajesComponent } from './viajes/crear-viajes/crear-viajes.component';

const routes: Routes = [
  {
    path: '',
    component: LandingPageComponent,
  },

  //seguridad
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'registro',
    component: RegistroComponent,
  },
  //paradas
  {
    path: 'paradas',
    component: IndiceParadasComponent,
    canActivate: [EsAdminGuard],
  },
  //distribucion
  {
    path: 'distribuciones',
    component: IndiceDistribucionComponent,
    canActivate: [EsAdminGuard],
  },
  {
    path: 'crear-distribucion',
    component: CrearDistribucionComponent,
    canActivate: [EsAdminGuard],
  },
  //clientes
  {
    path: 'clientes',
    component: IndiceClienteComponent,
    canActivate: [EsAdminGuard],
  },
  //viajes
  {
    path: 'viajes',
    component: IndiceViajesComponent,
    canActivate: [EsAdminGuard],
  },
  {
    path: 'crear-viaje',
    component: CrearViajesComponent,
    canActivate: [EsAdminGuard],
  },
  {
    path: 'crear-viajer/editar/:id',
    component: CrearViajesComponent,
    canActivate: [EsAdminGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
