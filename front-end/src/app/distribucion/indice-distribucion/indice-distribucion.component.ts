import { Component, Inject, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { MatTable } from '@angular/material/table';
import { parserarErroresAPI } from 'src/app/utilidades/utilidades';
import { DistribucionService } from '../distribucion.service';
import { distribucionDTO, DistribucionDTO } from '../distribucionDTO';
import { DistribucionComponent } from '../distribucion/distribucion.component';
import { DetalleDistribucionComponent } from '../detalle-distribucion/detalle-distribucion.component';
import { ConfirmComponent } from 'src/app/utilidades/confirm/confirm.component';
import { NotificacionesService } from 'src/app/utilidades/notificaciones.service';
@Component({
  selector: 'app-indice-distribucion',
  templateUrl: './indice-distribucion.component.html',
  styleUrls: ['./indice-distribucion.component.css'],
})
export class IndiceDistribucionComponent implements OnInit {
  constructor(
    private distribucionService: DistribucionService,
    public dialog: MatDialog,
    private notificacionesService: NotificacionesService
  ) {}

  cantidadTotalRegistros;
  paginaActual = 1;
  cantidadRegistrosAMostrar = 10;
  errores: string[] = [];

  distribuciones;

  @ViewChild(MatTable) table: MatTable<any>;
  ngOnInit(): void {
    this.cargarDistribuciones();
  }

  columnasAMostrar = ['id', 'nota', 'pisos', 'acciones'];

  cargarDistribuciones() {
    this.distribucionService.obtenerDistribuciones().subscribe(
      (result) => {
        this.distribuciones = result.result;
      },
      (error) => {
        this.errores = parserarErroresAPI(error);
        this.distribuciones = [];
      }
    );
  }

  openDialog(id: number) {}

  refreshDistribucion(pagina: number, cantidadRegistrosAMostrar: number) {}

  //    // listado
  obtenerParadas(pagina: number, cantidadRegistrosAMostrar: number) {}

  // paginacion
  actualizarPaginacion(datos: PageEvent) {}

  borrarRegistro(id: number) {}

  openDialogDetalle(id: number) {
    var dialogRef = this.dialog.open(DetalleDistribucionComponent, {
      width: '600px',
      data: id,
    });
  }

  // elimninar

  openDialogEliminar(distribucionDTO: distribucionDTO) {
    var dialogRef = this.dialog.open(ConfirmComponent, {
      width: '300px',
      data: {
        mensaje: '¿Desea eliminar permanentemente este registro?',
      },
    });

    dialogRef.beforeClosed().subscribe((result) => {
      result ? this.eliminar(distribucionDTO) : null;
    });
  }

  eliminar(distribucionDTO: distribucionDTO) {
    this.distribucionService.eliminar(distribucionDTO).subscribe(
      (result) => {
        if (result.body.success) {
          this.notificacionesService.showNotificacion(
            result.body.message,
            'x',
            'success'
          );
          this.cargarDistribuciones();
        }
      },
      (errorResult) => {
        this.notificacionesService.showNotificacion(
          errorResult.error.message,
          'x',
          'error'
        );
      }
    );
  }
}
