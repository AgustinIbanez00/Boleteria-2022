import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { MatTable } from '@angular/material/table';
import { parserarErroresAPI } from 'src/app/utilidades/utilidades';
import { DistribucionService } from '../distribucion.service';
import { DistribucionDTO } from '../distribucionDTO';

@Component({
  selector: 'app-indice-distribucion',
  templateUrl: './indice-distribucion.component.html',
  styleUrls: ['./indice-distribucion.component.css'],
})
export class IndiceDistribucionComponent implements OnInit {
  constructor(private distribucionService: DistribucionService) { }



  cantidadTotalRegistros;
  paginaActual = 1;
  cantidadRegistrosAMostrar = 10;
  errores: string[] = [];

  distribuciones;

  @ViewChild(MatTable) table: MatTable<any>;
  ngOnInit(): void {
    this.cargarDistribuciones()
  }

  columnasAMostrar = ['id', 'nota', 'pisos', 'acciones'];

  cargarDistribuciones() {
    this.distribucionService.obtenerDistribuciones().subscribe((result) => {
      this.distribuciones = result.result;
    }, (error) => { this.errores = parserarErroresAPI(error); this.distribuciones = [] })
  }

  openDialog(id: number) {

  }

  refreshDistribucion(pagina: number, cantidadRegistrosAMostrar: number) {

  }

  //    // listado
  obtenerParadas(pagina: number, cantidadRegistrosAMostrar: number) {

  }

  // paginacion
  actualizarPaginacion(datos: PageEvent) {

  }

  borrarRegistro(id: number) {

  }
}
