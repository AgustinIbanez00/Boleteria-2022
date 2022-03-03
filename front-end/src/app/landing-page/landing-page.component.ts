import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { ParadasService } from '../paradas/paradas.service';
import { paradasDTO } from '../paradas/paradasDTO';
import { parserarErroresAPI } from '../utilidades/utilidades';
import { webResultList } from '../utilidades/webResult';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {
  errores: string[] = []
  isLoading: boolean = false;
  form: FormGroup;
  paradas: paradasDTO[] = []
  filteredOptionsOrigen: Observable<paradasDTO[]>;
  filteredOptionsDestino: Observable<paradasDTO[]>;
  controlOrigen = new FormControl()
  controlDestino = new FormControl()
  constructor(private servicioParadas: ParadasService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      origen_id: ['', { validators: [Validators.required] }],
      destino_id: ['', { validators: [Validators.required] }],
      fecha_salida: ['', { validators: [Validators.required] }]
    })
    this.obtenerParadas()
    this.filteredOptionsOrigen = this.controlOrigen.valueChanges.pipe(
      startWith(''),
      map(name => (this._filter(name))),
    );
    this.filteredOptionsDestino = this.controlOrigen.valueChanges.pipe(
      startWith(''),
      map(name => (this._filter(name))),
    );
  }
  private _filter(name: string): paradasDTO[] {
    const filterValue = name.toLowerCase();

    return this.paradas.filter(option => option.descripcion.toLowerCase().includes(filterValue));
  }
  obtenerParadas() {
    this.servicioParadas
      .obtenerParadas(1, 50)
      .subscribe(
        (respuesta: HttpResponse<webResultList>) => {
          console.log(Object.values(respuesta.body)[1])
          this.paradas = Object.values(respuesta.body)[1];
        },
        (error) => {
          this.errores = parserarErroresAPI(error);
          this.paradas = [];
        }
      );
  }
  opcionSelectedOrigen(event: MatAutocompleteSelectedEvent) {
    var origen = this.paradas.find((item) => item.descripcion === event.option.value)
    this.form.get('origen_id').setValue(origen.id)
  }
  opcionSelectedDestino(event: MatAutocompleteSelectedEvent) {
    var origen = this.paradas.find((item) => item.descripcion === event.option.value)
    this.form.get('destino_id').setValue(origen.id)
    console.log(this.form.value)
  }
}
