import { identifierModuleUrl } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NotificacionesService } from 'src/app/utilidades/notificaciones.service';
import { parserarErroresAPI } from 'src/app/utilidades/utilidades';
import { DistribucionService } from '../distribucion.service';
import { DistribucionDTO, fila, cell, EstadosCeldas } from '../distribucionDTO';


@Component({
  selector: 'app-crear-distribucion',
  templateUrl: './crear-distribucion.component.html',
  styleUrls: ['./crear-distribucion.component.css']
})
export class CrearDistribucionComponent implements OnInit {
  estadosCeldas: EstadosCeldas = new EstadosCeldas();

  isLoading: boolean = false;
  errores: string[] = []
  piso0: fila[] = [];
  piso1: fila[] = [];
  pisoSelecctionado: number = 0;
  quitarFila: boolean = false
  form: FormGroup
  estiloEliminarFila: string = 'cursor:pointer'
  valoresEstados = Object.values(this.estadosCeldas).filter((item) => item != -1)
  constructor(private formBuilder: FormBuilder,
    private distribucionService: DistribucionService,
    private notificacionesService: NotificacionesService,
    private router: Router,) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      nota: ['', { validators: [Validators.required] }]
    })
  }
  guardarCambios(distribucion: DistribucionDTO) {
    console.log(distribucion)
    this.isLoading = true;
    this.distribucionService.guardarDistribucion(distribucion).subscribe((result) => {
      if (result.success) {
        this.notificacionesService.showNotificacion(result.message, 'x', 'success');
        this.router.navigate(['/distribuciones']);
      }
      else {
        this.notificacionesService.showNotificacion(result.error, 'x', 'error');
      }
      this.isLoading = false
    }, (error) => { this.errores = parserarErroresAPI(error); this.isLoading = false })
  }


}
