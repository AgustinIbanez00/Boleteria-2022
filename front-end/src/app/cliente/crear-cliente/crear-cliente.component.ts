import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CrearParadasComponent } from 'src/app/paradas/crear-paradas/crear-paradas.component';
import { NotificacionesService } from 'src/app/utilidades/notificaciones.service';
import { ClienteService } from '../cliente.service';
import { clienteDTO } from '../clienteDTO';

@Component({
  selector: 'app-crear-cliente',
  templateUrl: './crear-cliente.component.html',
  styleUrls: ['./crear-cliente.component.css'],
})
export class CrearClienteComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<CrearParadasComponent>,
    @Inject(MAT_DIALOG_DATA) public data: clienteDTO,
    public clienteService: ClienteService,
    private formBuilder: FormBuilder,

    private notificacionesService: NotificacionesService
  ) {}

  error_messages: Map<string, string[]> = new Map<string, string[]>();
  form: FormGroup;
  dto: clienteDTO;
  clientes: clienteDTO[];
  durationInSeconds = 3;

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      nombre: [
        '',
        { validators: [Validators.required, Validators.maxLength(100)] },
      ],
      dni: [
        '',
        {
          validators: [
            Validators.required,
            Validators.maxLength(8),
            Validators.minLength(8),
          ],
        },
      ],
      fechaNacimiento: ['', { validators: [Validators.required] }],
      nacionalidad: ['', { validators: [Validators.required] }],
      genero: ['', { validators: [Validators.required] }],
      // estado: 0,
    });

    if (this.data.dni !== undefined) {
      this.form.patchValue(this.data);
    }
  }

  // crear
  guardarCliente(clienteDTO: clienteDTO) {
    console.log(clienteDTO);
    if (this.data.dni != undefined) {
      console.log('editar');
      this.editar(clienteDTO);
    } else {
      console.log('crear');
      this.crear(clienteDTO);
    }
  }

  editar(clienteDTO: clienteDTO) {
    this.clienteService.editar(clienteDTO).subscribe(
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

  crear(clienteDTO: clienteDTO) {
    this.clienteService.crear(clienteDTO).subscribe(
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

  validacionesCliente(nombre: string) {
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

  validacionesRegistro(nombre: string) {
    var campo = this.form.get(nombre);
    if (campo.hasError('required')) {
      return 'Campo requerido';
    } else if (campo.hasError('email')) {
      return 'Formato email incorrecto';
    }
  }
}
