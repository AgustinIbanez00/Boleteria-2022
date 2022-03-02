import { Component, Input, OnInit } from '@angular/core';

import { paisDTO, provinciaDTO } from '../paisesDTO';

import { PaisesService } from '../paises.service';
import { HttpResponse } from '@angular/common/http';
import { webResultList } from '../../webResult';
import { parserarErroresAPI } from '../../utilidades';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-select',
  templateUrl: './select.component.html',
  styleUrls: ['./select.component.css'],
})
export class SelectComponent implements OnInit {
  constructor(public paisesService: PaisesService) {}

  @Input()
  form: FormControl;
  @Input()
  pais: string;
  @Input()
  provincia: string;
  @Input()
  validaciones;

  paises: paisDTO[] = [];
  provincias: provinciaDTO[] = [];
  errores: string[];

  ngOnInit() {
    this.obtenerPaises('');
    console.log(this.form.value);
    this.form.value[this.provincia] != '' &&
      this.buscarProvinciaPorPais(this.form.value[this.pais]);
  }

  // listado paises
  obtenerPaises(nomprePais: string) {
    this.paisesService.obtenerPaises(nomprePais).subscribe(
      (respuesta: HttpResponse<webResultList>) => {
        this.paises = Object.values(respuesta.body.result);
      },
      (error) => {
        this.errores = parserarErroresAPI(error);
      }
    );
  }

  // listado probincias por pais

  buscarProvinciaPorPais(idPais: number) {
    this.paisesService.obtenerProvincias(idPais).subscribe(
      (respuesta: HttpResponse<webResultList>) => {
        this.provincias = Object.values(respuesta.body.result);
      },
      (error) => {
        this.errores = parserarErroresAPI(error);
      }
    );
  }
}
