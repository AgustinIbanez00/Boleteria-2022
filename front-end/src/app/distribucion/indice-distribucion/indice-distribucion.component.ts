import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { MatTable } from '@angular/material/table';
import { distribucionDTO } from '../distribucionDTO';

@Component({
  selector: 'app-indice-distribucion',
  templateUrl: './indice-distribucion.component.html',
  styleUrls: ['./indice-distribucion.component.css'],
})
export class IndiceDistribucionComponent implements OnInit {
  constructor() { }

  @Input()
  distribucion;

  cantidadTotalRegistros;
  paginaActual = 1;
  cantidadRegistrosAMostrar = 10;
  errores: string[] = [];

  distribucionCole: distribucionDTO[] = [];

  ngOnInit(): void { }

  columnasAMostrar = ['id', 'nombre', 'acciones'];

  //agarrar referencia de la tabla
  @ViewChild(MatTable) table: MatTable<any>;

  openDialog(id: number) {
    // var dialogRef;
    // if (id === null) {
    //   dialogRef = this.dialog.open(CrearParadasComponent, {
    //     width: '800px',
    //     data: {
    //       id: this.id,
    //       nombre: this.nombre,
    //     },
    //   });
    // } else {
    //   var parada = this.paradas.find((it) => it.id === id);
    //   console.log('parada', parada);
    //   dialogRef = this.dialog.open(CrearParadasComponent, {
    //     width: '800px',
    //     data: parada,
    //   });
    // }
    // dialogRef.beforeClosed().subscribe((result) => {
    //   this.obtenerParadas(this.paginaActual, this.cantidadRegistrosAMostrar);
    // });
  }

  refreshDistribucion(pagina: number, cantidadRegistrosAMostrar: number) {
    //     this.distribucion = null;
    //     this.obtenerParadas(this.paginaActual, this.cantidadRegistrosAMostrar);
  }

  //    // listado
  obtenerParadas(pagina: number, cantidadRegistrosAMostrar: number) {
    //     this.paradaraService
    //       .obtenerParadas(pagina, cantidadRegistrosAMostrar)
    //       .subscribe(
    //         (respuesta: HttpResponse<webResult>) => {
    //           console.log('respuesta', respuesta.body);
    //           this.paradas = Object.values(respuesta.body.result);
    //           console.log(Object.values(respuesta.headers));
    //           this.cantidadTotalRegistros = respuesta.headers.get(
    //             'cantidadTotalRegistros'
    //           );
    //           console.log(this.cantidadTotalRegistros);
    //         },
    //         (error) => {
    //           this.errores = parserarErroresAPI(error);
    //         }
    //       );
  }

  // paginacion
  actualizarPaginacion(datos: PageEvent) {
    // this.paginaActual = datos.pageIndex + 1;
    // this.cantidadRegistrosAMostrar = datos.pageSize;
    // this.cargarRegistrosFiltrados(
    //   this.form.value,
    //   this.paginaActual,
    //   this.cantidadRegistrosAMostrar
    // );
  }
}
