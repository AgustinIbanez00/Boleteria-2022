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

@NgModule({
  declarations: [AppComponent, MenuComponent, AutorizadoComponent, ListadoParadasComponent, ListadoGenericoComponent, CrearParadasComponent, LandingPageComponent, IndiceParadasComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
