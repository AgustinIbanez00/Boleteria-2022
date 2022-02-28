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

@Component({
  selector: 'app-indice-paradas',
  templateUrl: './indice-paradas.component.html',
  styleUrls: ['./indice-paradas.component.css'],
})
export class IndiceParadasComponent implements OnInit {
  constructor(
    public dialog: MatDialog,
    public paradaraService: ParadasService,
    private formBuilder: FormBuilder
  ) { }

  @Input()
  paradas;

  id: number;
  nombre: string;
  cantidadTotalRegistros;
  paginaActual = 1;
  cantidadRegistrosAMostrar = 10;
  errores: string[] = [];

  paradasCole: paradasDTO[] = [];

  form: FormGroup;

  columnasAMostrar = ['id', 'nombre', 'acciones'];

  //agarrar referencia de la tabla
  @ViewChild(MatTable) table: MatTable<any>;

  ngOnInit(): void {
    this.obtenerParadas(this.paginaActual, this.cantidadRegistrosAMostrar),
      (this.form = this.formBuilder.group({
        nombre: [
          '',
          { validators: [Validators.required, Validators.maxLength(100)] },
        ],
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
      var producto = this.paradas[id];

      dialogRef = this.dialog.open(CrearParadasComponent, {
        width: '800px',
        data: producto,
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
          console.log('respuesta', respuesta.body);
          this.paradas = Object.values(respuesta.body.result);
          //this.paradas = [];

          // console.log('errores', respuesta.body.error_messages);
          // this.error_messages = respuesta.body.error_messages;

          // console.log(this.error_messages);
          //this.paradas = Object.values(respuesta.body.result);
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
}
