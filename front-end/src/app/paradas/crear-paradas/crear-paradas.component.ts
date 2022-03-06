import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { paradasDTO } from '../paradasDTO';
import { ParadasService } from '../paradas.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificacionesService } from 'src/app/utilidades/notificaciones.service';
import { PaisesService } from 'src/app/utilidades/paises/paises.service';
import { paisDTO } from 'src/app/utilidades/paises/paisesDTO';

@Component({
  selector: 'app-crear-paradas',
  templateUrl: './crear-paradas.component.html',
  styleUrls: ['./crear-paradas.component.css'],
})
export class CrearParadasComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<CrearParadasComponent>,
    @Inject(MAT_DIALOG_DATA) public data: paradasDTO,
    public paradaraService: ParadasService,
    private formBuilder: FormBuilder,
    public paisesService: PaisesService,
    private notificacionesService: NotificacionesService
  ) {}

  error_messages: Map<string, string[]> = new Map<string, string[]>();
  form: FormGroup;
  dto: paradasDTO;
  paradas: paradasDTO[];
  paises: paisDTO[];

  errores: string[] = [];

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: 0,
      nombre: [
        '',
        { validators: [Validators.required, Validators.maxLength(100)] },
      ],
      pais_id: ['', { validators: [Validators.required] }],
      provincia_id: ['', { validators: [Validators.required] }],
      estado: 1,
    });

    if (this.data.id !== undefined) {
      this.form.patchValue(this.data);
    }
  }

  // crear
  guardarParadas(paradasDTO: paradasDTO) {
    if (this.data.id != undefined) {
      this.editar(paradasDTO);
    } else {
      this.crear(paradasDTO);
    }
  }

  editar(paradasDTO: paradasDTO) {
    this.paradaraService.editar(paradasDTO).subscribe(
      (result) => {
        if (result.body.success) {
          this.notificacionesService.showNotificacion(
            result.body.message,
            'x',
            'success'
          );
          this.dialogRef.close('algo');
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

  crear(paradasDTO: paradasDTO) {
    this.paradaraService.crear(paradasDTO).subscribe(
      (result) => {
        if (result.body.success) {
          this.notificacionesService.showNotificacion(
            result.body.message,
            'x',
            'success'
          );
          this.dialogRef.close('algo');
        } else {
          console.log(result, paradasDTO);
          this.notificacionesService.showNotificacion(
            result.body.message,
            'x',
            'error'
          );
        }
      },
      (errorResult) => {
        console.log(errorResult, paradasDTO, 'aca');
        this.notificacionesService.showNotificacion(
          errorResult.error.message,
          'x',
          'error'
        );
      }
    );
  }

  validacionesParadas(nombre: string) {
    var campo = this.form.get(nombre);
    if (campo.hasError('required')) {
      return 'Campo ' + nombre + ' requerido';
    }
    if (campo.hasError('maxlength')) {
      return 'El minimo son 100 caracteres';
    }
    return '';
  }

  onClickNo() {
    this.dialogRef.close('algo');
  }
}
