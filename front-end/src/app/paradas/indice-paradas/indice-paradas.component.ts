import { HttpResponse } from '@angular/common/http';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { parserarErroresAPI } from 'src/app/utilidades/utilidades';
import { CrearParadasComponent } from '../crear-paradas/crear-paradas.component';
import { ParadasService } from '../paradas.service';
import { paradasDTO, paradasFiltroDTO } from '../paradasDTO';
import { PageEvent } from '@angular/material/paginator';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTable } from '@angular/material/table';
import { webResult, webResultList } from 'src/app/utilidades/webResult';
import { EstadosParadas } from 'src/app/utilidades/estados';
import { NotificacionesService } from 'src/app/utilidades/notificaciones.service';
import { ConfirmComponent } from 'src/app/utilidades/confirm/confirm.component';

@Component({
  selector: 'app-indice-paradas',
  templateUrl: './indice-paradas.component.html',
  styleUrls: ['./indice-paradas.component.css'],
})
export class IndiceParadasComponent implements OnInit {
  constructor(
    public dialog: MatDialog,
    public paradaraService: ParadasService,
    private formBuilder: FormBuilder,
    private notificacionesService: NotificacionesService
  ) {}
  @Input()
  paradas;

  id: number;
  nombre: string;
  cantidadTotalRegistros;
  paginaActual = 1;
  cantidadRegistrosAMostrar = 10;
  errores: string[] = [];
  estadosParadas = Object.entries(new EstadosParadas());
  isChecked = true;
  paradasCole: paradasDTO[] = [];

  form: FormGroup;

  columnasAMostrar = [
    'id',
    'estado',
    'nombre',
    'editar',
    'eliminar',
    'habilitar',
  ];

  paradasFiltroDTO: paradasFiltroDTO = { estado: null, nombre: null, id: null };

  //agarrar referencia de la tabla
  @ViewChild(MatTable) table: MatTable<any>;

  ngOnInit(): void {
    this.paginaActual = 1;
    // this.obtenerParadas(this.paginaActual, this.cantidadRegistrosAMostrar),
    this.cargarRegistrosFiltrados(
      this.paradasFiltroDTO,
      this.paginaActual,
      this.cantidadRegistrosAMostrar
    );
  }

  openDialog(id: number) {
    var dialogRef;
    if (id === null) {
      dialogRef = this.dialog.open(CrearParadasComponent, {
        width: '800px',
        data: {
          id: this.id,
          nombre: this.nombre,
        },
      });
    } else {
      var parada = this.paradas.find((it) => it.id === id);

      dialogRef = this.dialog.open(CrearParadasComponent, {
        width: '800px',
        data: parada,
      });
    }

    dialogRef.beforeClosed().subscribe((result) => {
      this.obtenerParadas(this.paginaActual, this.cantidadRegistrosAMostrar);
    });
  }

  refreshParadas(pagina: number, cantidadRegistrosAMostrar: number) {
    this.paradas = null;
    this.obtenerParadas(this.paginaActual, this.cantidadRegistrosAMostrar);
  }

  // listado
  obtenerParadas(pagina: number, cantidadRegistrosAMostrar: number) {
    this.paradaraService
      .obtenerParadas(pagina, cantidadRegistrosAMostrar)
      .subscribe(
        (respuesta: HttpResponse<webResultList>) => {
          this.paradas = Object.values(respuesta.body.result);
          console.log('respuesta', respuesta.body.pagination);

          this.cantidadTotalRegistros = respuesta.body.pagination.total_items;
        },
        (error) => {
          this.errores = parserarErroresAPI(error);
        }
      );
  }

  // paginacion
  actualizarPaginacion(datos: PageEvent) {
    console.log('actualizarPaginacion', datos);
    this.paginaActual = datos.pageIndex + 1;
    this.cantidadRegistrosAMostrar = datos.pageSize;

    this.cargarRegistrosFiltrados(
      this.paradasFiltroDTO,
      this.paginaActual,
      this.cantidadRegistrosAMostrar
    );
  }

  filtrar(paradasFiltroDTO: paradasFiltroDTO) {
    console.log('llego primero');
    this.paginaActual = 1;
    this.cargarRegistrosFiltrados(
      paradasFiltroDTO,
      this.paginaActual,
      this.cantidadRegistrosAMostrar
    );
  }

  // filtro
  cargarRegistrosFiltrados(
    paradasFiltroDTO: paradasFiltroDTO,
    pagina: number,
    cantidadRegistrosAMostrar: number
  ) {
    this.paradaraService
      .filtrarParadas(paradasFiltroDTO, pagina, cantidadRegistrosAMostrar)
      .subscribe(
        (respuesta: HttpResponse<webResultList>) => {
          this.paradas = Object.values(respuesta.body.result);
          console.log('respuesta', respuesta.body.pagination);
          console.log('53', respuesta.body.pagination.total_items);
          this.cantidadTotalRegistros = respuesta.body.pagination.total_items;
        },
        (error) => {
          this.errores = parserarErroresAPI(error);
        }
      );
  }

  hablitarDeshabilitar(event, parada: paradasDTO) {
    parada.estado = event.checked ? 1 : 0;
    this.editar(parada);
  }

  //editar
  editar(paradasDTO: paradasDTO) {
    this.paradaraService.editar(paradasDTO).subscribe(
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
        console.log('estocode', errorResult);

        this.notificacionesService.showNotificacion(
          errorResult.error.message,
          'x',
          'error'
        );
      }
    );
  }

  devolverEstado(estado: number) {
    return this.estadosParadas.filter((items) => {
      return items[1] == estado;
    })[0][0];
  }

  //eliminar
  eliminar(paradasDTO: paradasDTO) {
    this.paradaraService.eliminar(paradasDTO).subscribe(
      (result) => {
        if (result.body.success) {
          this.notificacionesService.showNotificacion(
            result.body.message,
            'x',
            'success'
          );
          this.obtenerParadas(
            this.paginaActual,
            this.cantidadRegistrosAMostrar
          );
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
  openDialogEliminar(paradasDTO: paradasDTO) {
    var dialogRef = this.dialog.open(ConfirmComponent, {
      width: '300px',
      data: {
        mensaje: '¿Desea eliminar permanentemente este registro?',
      },
    });

    dialogRef.beforeClosed().subscribe((result) => {
      result ? this.eliminar(paradasDTO) : null;
    });
  }
}
