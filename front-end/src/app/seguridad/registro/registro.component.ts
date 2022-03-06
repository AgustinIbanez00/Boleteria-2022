import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NotificacionesService } from 'src/app/utilidades/notificaciones.service';
import { parserarErroresAPI } from 'src/app/utilidades/utilidades';
import { registroDTO } from '../usuario';
import { UsuarioService } from '../usuario.service';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css'],
})
export class RegistroComponent implements OnInit {
  form: FormGroup;
  error_messages: Map<string, string[]> = new Map<string, string[]>();
  errores: string[] = [];
  isLoading: boolean = false;
  constructor(
    private formBuilder: FormBuilder,
    private registroService: UsuarioService,
    private router: Router,
    private notificacionesService: NotificacionesService
  ) {}

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      email: ['', { validators: [Validators.email] }],
      password: ['', { validators: [Validators.required] }],
      confirm_password: ['', { validators: [Validators.required] }],
      first_name: ['', { validators: [Validators.required] }],
      last_name: ['', { validators: [Validators.required] }],
      dni: ['', { validators: [Validators.required] }],
      fecha_nacimiento: ['', { validators: [Validators.required] }],
    });
  }

  validacionesRegistro(nombre: string) {
    var campo = this.form.get(nombre);
    if (campo.hasError('required')) {
      return 'Campo requerido';
    } else if (campo.hasError('email')) {
      return 'Formato email incorrecto';
    }
  }
  submit(registro: registroDTO) {
    this.error_messages = new Map<string, string[]>();
    if (registro.password !== registro.confirm_password) {
      this.error_messages['confirm_password'] = [
        'Las contraseñas no coinciden',
      ];
    } else {
      this.isLoading = true;
      this.registroService.crearUsuario(registro).subscribe(
        (result) => {
          if (!result.success) {
            this.error_messages = result.error_messages;
          } else {
            this.notificacionesService.showNotificacion(
              result.message,
              'x',
              'success'
            );
            this.router.navigate(['/login']);
          }
          this.isLoading = false;
        },
        (error) => {
          (this.errores = parserarErroresAPI(error)), (this.isLoading = false);
        }
      );
    }
  }
}
