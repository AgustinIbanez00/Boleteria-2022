import { HttpResponse } from '@angular/common/http';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { MatTable } from '@angular/material/table';
import { ConfirmComponent } from 'src/app/utilidades/confirm/confirm.component';
import { EstadosViajes } from 'src/app/utilidades/estados';
import { NotificacionesService } from 'src/app/utilidades/notificaciones.service';
import { parserarErroresAPI } from 'src/app/utilidades/utilidades';
import { webResultList } from 'src/app/utilidades/webResult';
import { CrearViajesComponent } from '../crear-viajes/crear-viajes.component';
import { horarioDTO, viajeDTO, viajeFiltroDTO } from '../viajaeDTO';
import { ViajesService } from '../viajes.service';

@Component({
  selector: 'app-indice-viajes',
  templateUrl: './indice-viajes.component.html',
  styleUrls: ['./indice-viajes.component.css'],
})
export class IndiceViajesComponent implements OnInit {
  constructor(
    public dialog: MatDialog,
    public viajesService: ViajesService,
    private formBuilder: FormBuilder,
    private notificacionesService: NotificacionesService
  ) {}

  @Input()
  viajes;

  cantidadTotalRegistros;
  paginaActual = 1;
  cantidadRegistrosAMostrar = 10;
  errores: string[] = [];
  estadosViajes = Object.entries(new EstadosViajes());

  //form: FormGroup;

  columnasAMostrar = [
    'id',
    'estado',
    'nombre',
    'editar',
    'eliminar',
    'habilitar',
  ];

  viajeFiltroDTO: viajeFiltroDTO = {
    estado: null,
    nombre: null,
    id: null,
  };

  //agarrar referencia de la tabla
  @ViewChild(MatTable) table: MatTable<any>;

  ngOnInit(): void {
    this.paginaActual = 1;

    this.cargarRegistrosFiltrados(
      this.viajeFiltroDTO,
      this.paginaActual,
      this.cantidadRegistrosAMostrar
    );
  }

  refreshViajes(pagina: number, cantidadRegistrosAMostrar: number) {
    this.viajes = null;
    this.obtenerViajes(this.paginaActual, this.cantidadRegistrosAMostrar);
  }

  // listado
  obtenerViajes(pagina: number, cantidadRegistrosAMostrar: number) {
    this.viajesService
      .obtenerViajes(pagina, cantidadRegistrosAMostrar)
      .subscribe(
        (respuesta: HttpResponse<webResultList>) => {
          this.viajes = Object.values(respuesta.body.result);

          this.cantidadTotalRegistros = respuesta.body.pagination.total_items;
        },
        (error) => {
          this.errores = parserarErroresAPI(error);
          this.viajes = [];
        }
      );
  }

  // paginacion
  actualizarPaginacion(datos: PageEvent) {
    this.paginaActual = datos.pageIndex + 1;
    this.cantidadRegistrosAMostrar = datos.pageSize;

    this.cargarRegistrosFiltrados(
      this.viajeFiltroDTO,
      this.paginaActual,
      this.cantidadRegistrosAMostrar
    );
  }

  filtrar(viajeFiltroDTO: viajeFiltroDTO) {
    this.paginaActual = 1;
    this.cargarRegistrosFiltrados(
      viajeFiltroDTO,
      this.paginaActual,
      this.cantidadRegistrosAMostrar
    );
  }

  // filtro
  cargarRegistrosFiltrados(
    viajeFiltroDTO: viajeFiltroDTO,
    pagina: number,
    cantidadRegistrosAMostrar: number
  ) {
    this.viajesService
      .filtrarViajes(viajeFiltroDTO, pagina, cantidadRegistrosAMostrar)
      .subscribe(
        (respuesta: HttpResponse<webResultList>) => {
          this.viajes = Object.values(respuesta.body.result);
          this.cantidadTotalRegistros = respuesta.body.pagination.total_items;
        },
        (error) => {
          this.errores = parserarErroresAPI(error);
        }
      );
  }

  hablitarDeshabilitar(event, viaje: viajeDTO) {
    viaje.estado = event.checked ? 1 : 0;
    console.log(viaje);
    this.editar(viaje);
  }

  //editar
  editar(viajeDTO: viajeDTO) {
    this.viajesService.editar(viajeDTO).subscribe(
      (result) => {
        if (result.body.success) {
          this.notificacionesService.showNotificacion(
            result.body.message,
            'x',
            'success'
          );
        } else {
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

  //eliminar
  eliminar(viajeDTO: viajeDTO) {
    this.viajesService.eliminar(viajeDTO).subscribe(
      (result) => {
        if (result.body.success) {
          this.notificacionesService.showNotificacion(
            result.body.message,
            'x',
            'success'
          );
          this.obtenerViajes(this.paginaActual, this.cantidadRegistrosAMostrar);
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
  openDialogEliminar(viajaeDTO: viajeDTO) {
    var dialogRef = this.dialog.open(ConfirmComponent, {
      width: '300px',
      data: {
        mensaje: '¿Desea eliminar permanentemente este registro?',
      },
    });

    dialogRef.beforeClosed().subscribe((result) => {
      result ? this.eliminar(viajaeDTO) : null;
    });
  }

  devolverEstado(estado: number) {
    return this.estadosViajes.filter((items) => {
      return items[1] == estado;
    })[0][0];
  }
}
