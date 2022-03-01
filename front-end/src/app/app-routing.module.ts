import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EsAdminGuard } from './es-admin.guard';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { IndiceParadasComponent } from './paradas/indice-paradas/indice-paradas.component';
import { LoginComponent } from './seguridad/login/login.component';
import { RegistroComponent } from './seguridad/registro/registro.component';
import { IndiceDistribucionComponent } from './distribucion/indice-distribucion/indice-distribucion.component';
import { CrearDistribucionComponent } from './distribucion/crear-distribucion/crear-distribucion.component';

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
    path: "registro",
    component: RegistroComponent
  },
  //destinos
  {
    path: 'paradas',
    component: IndiceParadasComponent,
    canActivate: [EsAdminGuard],
  },
  //distribucion
  {
    path: 'distribucion',
    component: IndiceDistribucionComponent
  },
  {
    path: 'crear-distribucion',
    component: CrearDistribucionComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
