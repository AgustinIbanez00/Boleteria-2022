import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { parserarErroresAPI } from 'src/app/utilidades/utilidades';
import { DistribucionService } from '../distribucion.service';
import { distribucionDTO, DistribucionDTO, fila, filaDTO } from '../distribucionDTO';

@Component({
  selector: 'app-detalle-distribucion',
  templateUrl: './detalle-distribucion.component.html',
  styleUrls: ['./detalle-distribucion.component.css']
})
export class DetalleDistribucionComponent implements OnInit {

  contadorPiso0: number = 0
  contadoPiso1: number = 0
  errores: string[] = []
  isLoading: boolean = false;
  piso0 = [];
  piso1 = [];
  distribucionDTO: DistribucionDTO = new DistribucionDTO()
  distribucion: distribucionDTO;
  constructor(
    public dialogRef: MatDialogRef<DetalleDistribucionComponent>,
    @Inject(MAT_DIALOG_DATA) public data: number,
    private distribucionService: DistribucionService
  ) { }

  ngOnInit(): void {
    this.isLoading = true;
    this.distribucionService.obtenerDistribucion(this.data).subscribe((result) => {
      this.distribucion = { id: result.result['id'], filas: result.result['filas'], nota: result.result['nota'], un_piso: result.result['un_piso'] }
      this.piso0 = this.distribucion.filas.filter(item => item.planta === 0)
      this.aumentarContadorPiso(this.piso0)
      if (!this.distribucion.un_piso) {
        this.piso1 = this.distribucion.filas.filter(item => item.planta === 1)
        this.aumentarContadorPiso(this.piso1)
      }
    }, (error) => { this.errores = parserarErroresAPI(error); })
  }

  devolverIconoCelda(value: number, celda: boolean) {
    return this.distribucionDTO.devolverIcono(value, celda)
  }

  devolverTextiToolTips(value: number) {
    return this.distribucionDTO.devolverDescripcion(value)
  }
  aumentarContadorPiso(piso: any[]) {
    var contador = 1;
    piso.map((item) => {
      item.cells.map((celda) => {
        if (celda.value === 2 || celda.value === 6 || celda.value === 7)
          celda.numero = contador++;
      })
    })
  }
}
