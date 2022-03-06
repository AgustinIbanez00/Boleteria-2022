import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { horarioDTO } from 'src/app/viajes/viajaeDTO';
import { EnumDiasSemana } from '../EnumDiasSemana';

@Component({
  selector: 'app-horarios',
  templateUrl: './horarios.component.html',
  styleUrls: ['./horarios.component.css'],
})
export class HorariosComponent implements OnInit {
  constructor(private formBuilder: FormBuilder) {}

  @Output()
  cargarHorario: EventEmitter<horarioDTO> = new EventEmitter<horarioDTO>();

  formHorario: FormGroup;
  listDias: number[] = [];

  listDiasSemana: { descripcion: string; value: number }[] = [];
  ngOnInit(): void {
    this.formHorario = this.formBuilder.group({
      hora: ['', { validators: [Validators.required] }],
      dias: [[], { validators: [Validators.required] }],
      distribucion_id: ['', { validators: [Validators.required] }],
    });

    //console.log(this.formHorario);
    this.obtenerDias();
  }

  obtenerDias() {
    let a = Object.keys(EnumDiasSemana)
      .map((key) => EnumDiasSemana[key])
      .filter((value) => typeof value === 'string') as string[];

    for (let i = 0; i < a.length; i++) {
      this.listDiasSemana.push({
        descripcion: a[i],
        value: i,
      });
    }
  }

  guardarHorario(horario: horarioDTO) {
    var horario: horarioDTO = JSON.parse(JSON.stringify(horario));
    this.cargarHorario.emit(horario);
  }

  guardarDia(dia_id: number) {
    var dia_existente = this.listDias.find((id) => id == dia_id);

    if (dia_existente !== undefined) {
      var indice = this.listDias.indexOf(dia_id);
      this.listDias.splice(indice, 1);
    } else {
      this.listDias.push(dia_id);
    }

    this.formHorario.get('dias').setValue(this.listDias);
  }
}
