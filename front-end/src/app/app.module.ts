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
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { ConfirmComponent } from './utilidades/confirm/confirm.component';
import { CrearDistribucionComponent } from './distribucion/crear-distribucion/crear-distribucion.component';
import { IndiceClienteComponent } from './cliente/indice-cliente/indice-cliente.component';
import { CrearClienteComponent } from './cliente/crear-cliente/crear-cliente.component';
import { ListadoClienteComponent } from './cliente/listado-cliente/listado-cliente.component';
import { MatSelectModule } from '@angular/material/select';

import { FiltroParadasComponent } from './paradas/filtro-paradas/filtro-paradas.component';
import { FiltroClienteComponent } from './cliente/filtro-cliente/filtro-cliente.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { SelectComponent } from './utilidades/paises/select/select.component';
import { DistribucionComponent } from './distribucion/distribucion/distribucion.component';
import { DetalleDistribucionComponent } from './distribucion/detalle-distribucion/detalle-distribucion.component';
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
    ConfirmComponent,
    CrearDistribucionComponent,
    IndiceClienteComponent,
    CrearClienteComponent,
    ListadoClienteComponent,
    FiltroParadasComponent,
    FiltroClienteComponent,
    SelectComponent,
    DistribucionComponent,
    DetalleDistribucionComponent
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
    SweetAlert2Module.forRoot(),
    MatSelectModule,
    MatAutocompleteModule,
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
export class AppModule { }
