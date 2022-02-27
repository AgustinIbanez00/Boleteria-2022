import { HttpResponse } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { webResult } from 'src/app/utilidades/listado-generico/weResult';
import { parserarErroresAPI } from 'src/app/utilidades/utilidades';
import { CrearParadasComponent } from '../crear-paradas/crear-paradas.component';
import { ParadasService } from '../paradas.service';
import { paradasDTO } from '../paradasDTO';

@Component({
  selector: 'app-indice-paradas',
  templateUrl: './indice-paradas.component.html',
  styleUrls: ['./indice-paradas.component.css'],
})
export class IndiceParadasComponent implements OnInit {
  constructor(
    public dialog: MatDialog,
    public paradaraService: ParadasService
  ) { }

  @Input()
  paradas;

  id: number;
  estado: number;
  nombre: string;
  cantidadTotalRegistros;
  paginaActual = 1;
  cantidadRegistrosAMostrar = 10;
  errores: string[] = [];

  paradasCole: paradasDTO[] = [];

  ngOnInit(): void { }

  openDialog(id: number) {
    var dialogRef;
    if (id === null) {
      dialogRef = this.dialog.open(CrearParadasComponent, {
        width: '800px',
        data: {
          id: this.id,
          nombre: this.nombre,
          estado: this.estado,
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
      this.obtenerMisProductos(
        this.paginaActual,
        this.cantidadRegistrosAMostrar
      );
    });
  }
  obtenerMisProductos(pagina: number, cantidadRegistrosAMostrar: number) {
    // this.paradaraService
    //   .obtenerParadas(pagina, cantidadRegistrosAMostrar)
    //   .subscribe(
    //     (respuesta: HttpResponse<webResult>) => {
    //       this.paradas = Object.values(respuesta.body.data);

    //       this.cantidadTotalRegistros = respuesta.headers.get(
    //         'cantidadTotalRegistros'
    //       );
    //     },
    //     (error) => {
    //       this.errores = parserarErroresAPI(error);
    //     }
    //   );
  }
}
