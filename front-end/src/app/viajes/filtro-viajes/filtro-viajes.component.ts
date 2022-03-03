import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { paradasFiltroDTO } from 'src/app/paradas/paradasDTO';
import { viajeFiltroDTO } from '../viajaeDTO';

@Component({
  selector: 'app-filtro-viajes',
  templateUrl: './filtro-viajes.component.html',
  styleUrls: ['./filtro-viajes.component.css'],
})
export class FiltroViajesComponent implements OnInit {
  constructor(private formBuilder: FormBuilder) {}

  form: FormGroup;

  @Output()
  OnSubmit: EventEmitter<viajeFiltroDTO> = new EventEmitter<viajeFiltroDTO>();

  @Input()
  viajes;

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      nombre: [null, { validators: [Validators.maxLength(100)] }],
      estado: -1,
    });
  }

  filtrarParadas(viajeFiltroDTO: viajeFiltroDTO) {
    this.OnSubmit.emit(viajeFiltroDTO);
  }
}
