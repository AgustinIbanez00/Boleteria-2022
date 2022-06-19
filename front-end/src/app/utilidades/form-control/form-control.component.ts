import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-form-control',
  templateUrl: './form-control.component.html',
  styleUrls: ['./form-control.component.css']
})
export class FormControlComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) { }
  @Input()
  type: string = "text"
  @Input()
  propiedad: string;
  @Input()
  form: FormGroup = this.formBuilder.group({})
  @Input()
  error_messages: Map<string, string[]> = new Map<string, string[]>();
  @Input()
  validaciones;
  @Input()
  textoLabel: string = ''
  @Input()
  clase: string = 'inputDefault'
  @Input()
  apareance: string = 'outline'
  hidePassword: boolean = false;

  ngOnInit(): void {
  }

  validar(propiedad: string) {
    if (this.validaciones) {
      this.validaciones(propiedad)
    }

  }
}
