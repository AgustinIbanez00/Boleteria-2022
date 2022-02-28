import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { paradasDTO } from '../paradasDTO';
import { ParadasService } from '../paradas.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificacionesService } from 'src/app/utilidades/notificaciones.service';

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

    private notificacionesService: NotificacionesService
  ) { }

  error_messages: Map<string, string[]> = new Map<string, string[]>();
  form: FormGroup;
  dto: paradasDTO;
  paradas: paradasDTO[];
  durationInSeconds = 3;

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      nombre: [
        '',
        { validators: [Validators.required, Validators.maxLength(100)] },
      ],
    });

    if (this.data.id !== undefined) {
      this.form.patchValue(this.data);
    }
  }

  // crear
  guardarParadas(paradasDTO: paradasDTO) {
    console.log(paradasDTO);
    if (this.data.id != undefined) {
      console.log('editar');
      this.editar(paradasDTO);
    } else {
      console.log('crear');
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

  validacionesParadas(nombre: string) {
    var campo = this.form.get(nombre);
    if (campo.hasError('required')) {
      return 'Campo requerido';
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
