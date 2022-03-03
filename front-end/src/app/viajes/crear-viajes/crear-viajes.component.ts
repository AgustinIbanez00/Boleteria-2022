import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';

import { NotificacionesService } from 'src/app/utilidades/notificaciones.service';
import { parserarErroresAPI } from 'src/app/utilidades/utilidades';
import { viajeDTO } from '../viajaeDTO';
import { ViajesService } from '../viajes.service';

@Component({
  selector: 'app-crear-viajes',
  templateUrl: './crear-viajes.component.html',
  styleUrls: ['./crear-viajes.component.css'],
})
export class CrearViajesComponent implements OnInit {
  constructor(
    public viajesService: ViajesService,
    private formBuilder: FormBuilder,
    private notificacionesService: NotificacionesService,
    private activatedRoute: ActivatedRoute
  ) {}

  error_messages: Map<string, string[]> = new Map<string, string[]>();
  form: FormGroup;
  viaje: viajeDTO;
  idViaje: number;
  errores: string[] = [];
  isLoading = false;
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(
      (params) => {
        this.idViaje = params.id;
        if (this.idViaje) {
          this.isLoading = true;
          this.viajesService.obtenerViaje(this.idViaje).subscribe(
            (result) => {
              this.viaje = Object.values(result)[0];
              this.isLoading = false;
            },
            (error) => {
              this.errores = parserarErroresAPI(error);
              this.isLoading = false;
            }
          );
        }
      },
      (error) => {
        this.errores = parserarErroresAPI(error);
      }
    );
    // this.form = this.formBuilder.group({
    //   nombre: [
    //     '',
    //     { validators: [Validators.required, Validators.maxLength(100)] },
    //   ],
    //   horarios: ['', { validators: [Validators.required] }],
    // });
    // if (this.data.id !== undefined) {
    //   this.form.patchValue(this.data);
    // }
  }

  // crear
  // guardarViajes(viajeDTO: viajeDTO) {

  //   // if (this.data.id != undefined) {
  //   //   this.editar(viajeDTO);
  //   // } else {
  //   this.crear(viajeDTO);
  //   // }
  // }

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
          this.notificacionesService.showNotificacion(
            result.body.message,
            'x',
            'error'
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

  crear(viajeDTO: viajeDTO) {
    this.viajesService.crear(viajeDTO).subscribe(
      (result) => {
        if (result.body.success) {
          this.notificacionesService.showNotificacion(
            result.body.message,
            'x',
            'success'
          );
        } else {
          this.notificacionesService.showNotificacion(
            result.body.message,
            'x',
            'error'
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

  // validacionesViajes(nombre: string) {
  //   var campo = this.form.get(nombre);
  //   if (campo.hasError('required')) {
  //     return 'Campo ' + nombre + ' requerido';
  //   }
  //   if (campo.hasError('maxlength')) {
  //     return 'El minimo son 100 caracteres';
  //   }
  //   return '';
  // }
}
