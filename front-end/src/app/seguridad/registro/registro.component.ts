import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { registroDTO } from './registro';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {

  form: FormGroup;
  errores: string[] = []
  constructor(
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      email: ['', { validators: [Validators.email] }],
      password: ['', { validators: [Validators.required] }],
      confirm_password: ['', { validators: [Validators.required] }],
      first_name: ['', { validators: [Validators.required] }],
      last_name: ['', { validators: [Validators.required] }],
      dni: ['', { validators: [Validators.required] }],
      fecha_nacimiento: ['', { validators: [Validators.required] }]
    })
  }

  validacionesProducto(nombre: string) {
    var campo = this.form.get(nombre);
    if (campo.hasError('required')) {
      return 'Campo requerido';
    }
    else if (campo.hasError('email')) {
      return 'Formato email incorrecto';
    }
  }
  submit(registro: registroDTO) {
    this.errores = []
    if (registro.password !== registro.confirm_password) {
      this.errores.push("Las contraseñas no coinciden")
    }
    else {
      console.log(registro)
    }
  }
}
