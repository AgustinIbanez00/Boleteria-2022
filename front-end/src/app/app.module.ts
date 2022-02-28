import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu/menu.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MaterialModule } from './material/material.module';
import { AutorizadoComponent } from './seguridad/autorizado/autorizado/autorizado.component';
import { ListadoParadasComponent } from './paradas/listado-paradas/listado-paradas.component';
import { ListadoGenericoComponent } from './utilidades/listado-generico/listado-generico.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CrearParadasComponent } from './paradas/crear-paradas/crear-paradas.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { IndiceParadasComponent } from './paradas/indice-paradas/indice-paradas.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { RegistroComponent } from './seguridad/registro/registro.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MostrarErroresComponent } from './utilidades/mostrar-errores/mostrar-errores.component';
import { LoadingComponent } from './utilidades/loading/loading.component';
import { FormControlComponent } from './utilidades/form-control/form-control.component';
import { LoginComponent } from './seguridad/login/login.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { NotificacionesComponent } from './utilidades/notificaciones/notificaciones.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { SeguridadInterceptorService } from './seguridad/interceptor.service';
import { IndiceDistribucionComponent } from './distribucion/indice-distribucion/indice-distribucion.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    AutorizadoComponent,
    ListadoParadasComponent,
    ListadoGenericoComponent,
    CrearParadasComponent,
    LandingPageComponent,
    IndiceParadasComponent,
    RegistroComponent,
    MostrarErroresComponent,
    NotificacionesComponent,
    LoginComponent,
    LoadingComponent,
    FormControlComponent,
    IndiceDistribucionComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    MatPaginatorModule,
    ReactiveFormsModule,
    MatInputModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
    MatSlideToggleModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: SeguridadInterceptorService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
