import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DistribucionService } from 'src/app/distribucion/distribucion.service';
import { distribucionDTO, DistribucionDTO } from 'src/app/distribucion/distribucionDTO';
import { NotificacionesService } from 'src/app/utilidades/notificaciones.service';
import { parserarErroresAPI } from 'src/app/utilidades/utilidades';

@Component({
  selector: 'app-comprar-boleto',
  templateUrl: './comprar-boleto.component.html',
  styleUrls: ['./comprar-boleto.component.css']
})
export class ComprarBoletoComponent implements OnInit {
  form: FormGroup;
  contadorPiso0: number = 0
  errores: string[] = []
  isLoading: boolean = false;
  piso0 = [];
  piso1 = [];
  distribucionDTO: DistribucionDTO = new DistribucionDTO()
  distribucion: distribucionDTO;
  contador = 1;
  asientoSeleccionado = '-'
  constructor(
    public dialogRef: MatDialogRef<ComprarBoletoComponent>,
    @Inject(MAT_DIALOG_DATA) public data: number,
    private distribucionService: DistribucionService,
    private formBuilder: FormBuilder,
    private notificacionesService: NotificacionesService
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

    piso.map((item) => {
      item.cells.map((celda) => {
        if (celda.value === 2 || celda.value === 6 || celda.value === 7)
          celda.numero = this.contador++;
      })
    })
  }

  seleccionarAsiento(celda: any) {
    if (celda.value == 2 || celda.value == 6 || celda.value == 7) {
      this.asientoSeleccionado = celda.numero
    }
  }

  comprarBoleto() {
    this.notificacionesService.showNotificacion("Boleto comprado con éxito", "X", "success")
  }
}
