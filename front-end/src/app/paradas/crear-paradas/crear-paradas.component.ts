import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { paradasDTO } from '../paradasDTO';
import { ParadasService } from '../paradas.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
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
    private _snackBar: MatSnackBar,
    private notificacionesService: NotificacionesService
  ) {}

  error_messages: Map<string, string[]> = new Map<string, string[]>();
  form: FormGroup;
  dto: paradasDTO;
  paradas: paradasDTO[];
  durationInSeconds = 3;

  ngOnInit(): void {
    // this.dto = { nombre: '', id: 0 };
    // this.guardarParadas(this.dto);

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
    this.paradaraService.crear(paradasDTO).subscribe((result) => {
      if (result.success) {
        this.notificacionesService.showNotifacion(result.message, 'x', 'error');
        this.dialogRef.close('algo');
      }
      console.log('respuest', result);
      this.error_messages = result.error_messages;
      console.log('respuest', this.error_messages);
    });
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
