import { HttpResponse } from '@angular/common/http';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { parserarErroresAPI } from 'src/app/utilidades/utilidades';
import { CrearParadasComponent } from '../crear-paradas/crear-paradas.component';
import { ParadasService } from '../paradas.service';
import { paradasDTO } from '../paradasDTO';
import { PageEvent } from '@angular/material/paginator';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTable } from '@angular/material/table';
import { webResult } from 'src/app/utilidades/webResult';
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
  ) { }
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

  //agarrar referencia de la tabla
  @ViewChild(MatTable) table: MatTable<any>;

  ngOnInit(): void {
    this.obtenerParadas(this.paginaActual, this.cantidadRegistrosAMostrar),
      (this.form = this.formBuilder.group({
        nombre: [
          '',
          { validators: [Validators.required, Validators.maxLength(100)] },
        ],
        estado: 0,
      }));

    this.form.valueChanges.subscribe((valores) => {
      this.cargarRegistrosFiltrados(
        valores,
        this.paginaActual,
        this.cantidadRegistrosAMostrar
      );
    });
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
      console.log('parada', parada);
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
        (respuesta: HttpResponse<webResult>) => {
          this.paradas = Object.values(respuesta.body.result);
          console.log('respuesta', Object.values(respuesta.headers));
          this.paradas = Object.values(respuesta.body.result);
          this.cantidadTotalRegistros = respuesta.headers.get(
            'cantidadTotalRegistros'
          );
        },
        (error) => {
          this.errores = parserarErroresAPI(error);
        }
      );
  }

  // paginacion
  actualizarPaginacion(datos: PageEvent) {
    this.paginaActual = datos.pageIndex + 1;
    this.cantidadRegistrosAMostrar = datos.pageSize;
    // this.cargarRegistrosFiltrados(
    //   this.form.value,
    //   this.paginaActual,
    //   this.cantidadRegistrosAMostrar
    // );
  }

  // filtro
  cargarRegistrosFiltrados(
    valores: any,
    pagina: number,
    cantidadRegistrosAMostrar: number
  ) {
    // valores.pagina = pagina;
    // valores.recordsPorPagina = cantidadRegistrosAMostrar;
    // this.productoService.filtrarMisProductos(valores).subscribe(
    //   (respuesta: HttpResponse<webResult>) => {
    //     if (respuesta.body.success) {
    //       this.misProductos = Object.values(respuesta.body.data);
    //       this.cantidadTotalRegistros = respuesta.headers.get(
    //         'cantidadTotalRegistros'
    //       );
    //     } else {
    //       if (
    //         respuesta.body.errorList &&
    //         respuesta.body.errorList.length != 0
    //       ) {
    //         this.errores.push(...respuesta.body.errorList);
    //       } else {
    //         this.errores.push(respuesta.body.error);
    //       }
    //     }
    //   },
    //   (error) => {
    //     this.errores = parserarErroresAPI(error);
    //   }
    //);
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
        console.log(result);
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
        console.log('estocode', errorResult);

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
