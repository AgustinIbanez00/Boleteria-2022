import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { clienteFiltroDTO } from '../clienteDTO';

@Component({
  selector: 'app-filtro-cliente',
  templateUrl: './filtro-cliente.component.html',
  styleUrls: ['./filtro-cliente.component.css'],
})
export class FiltroClienteComponent implements OnInit {
  constructor(private formBuilder: FormBuilder) {}

  @Input()
  clientes;

  form: FormGroup;

  @Output()
  OnSubmit: EventEmitter<clienteFiltroDTO> = new EventEmitter<clienteFiltroDTO>();

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      nombre: [null, { validators: [Validators.maxLength(100)] }],
      estado: -1,
      dni: [null, { validators: [Validators.maxLength(8)] }],
    });
  }

  filtrarClientes(clienteFiltroDTO: clienteFiltroDTO) {
    this.OnSubmit.emit(clienteFiltroDTO);
  }
}
