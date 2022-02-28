import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { parserarErroresAPI } from 'src/app/utilidades/utilidades';
import { SeguridadService } from '../seguridad.service';
import { loginDTO } from '../usuario';
import { UsuarioService } from '../usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  isLoading: boolean = false;
  form: FormGroup;
  errores: string[] = []
  error_messages: Map<string, string[]> = new Map<string, string[]>();
  constructor(private formBuilder: FormBuilder,
    private usuarioService: UsuarioService,
    private seguridadService: SeguridadService) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      email: ['', { validators: [Validators.email, Validators.required] }],
      password: ['', { validators: [Validators.required] }]
    })
  }
  validacionesLogin(nombre: string) {
    var campo = this.form.get(nombre);
    if (campo.hasError('required')) {
      return 'Campo requerido';
    }
    else if (campo.hasError('email')) {
      return 'Formato email incorrecto';
    }
  }

  submit(login: loginDTO) {
    this.isLoading = true;
    this.usuarioService.login(login).subscribe((result) => {
      this.isLoading = false;
      if (result.success) {
        this.seguridadService.guardarToken(result.result['token'])
      }
      console.log(result)
    }, (error) => { this.errores = parserarErroresAPI(error); this.isLoading = false; })
  }

}
