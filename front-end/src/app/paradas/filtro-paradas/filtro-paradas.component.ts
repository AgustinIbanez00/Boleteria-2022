import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { paradasFiltroDTO } from '../paradasDTO';

@Component({
  selector: 'app-filtro-paradas',
  templateUrl: './filtro-paradas.component.html',
  styleUrls: ['./filtro-paradas.component.css'],
})
export class FiltroParadasComponent implements OnInit {
  constructor(private formBuilder: FormBuilder) {}

  form: FormGroup;

  @Output()
  OnSubmit: EventEmitter<paradasFiltroDTO> = new EventEmitter<paradasFiltroDTO>();

  @Input()
  paradas;
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      nombre: [null, { validators: [Validators.maxLength(100)] }],
      estado: -1,
    });
  }

  // compareObjects(value: number, estado: number): boolean {
  //   return value === estado;
  // }

  filtrarParadas(paradasFiltroDTO: paradasFiltroDTO) {
    this.OnSubmit.emit(paradasFiltroDTO);
  }
}
