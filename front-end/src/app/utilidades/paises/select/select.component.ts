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
  @Input()
  usarParadas: boolean = false;

  paises: paisDTO[] = [];
  provincias: provinciaDTO[] = [];
  errores: string[];

  ngOnInit() {
    console.log(this.form);
    this.obtenerPaises('');

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

  validar(campo: string) {
    if (this.validaciones != undefined) {
      this.validaciones(campo);
    } else {
      var propiedad = this.form.get(campo);

      if (propiedad.hasError('required')) {
        return 'Campo requerido';
      } else if (propiedad.hasError('maxlength')) {
        return 'El minimo son 100 caracteres';
      }

      return '';
    }
  }
}
