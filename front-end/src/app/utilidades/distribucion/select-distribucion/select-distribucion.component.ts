import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { DistribucionService } from 'src/app/distribucion/distribucion.service';
import {
  distribucionDTO,
  DistribucionDTO,
} from 'src/app/distribucion/distribucionDTO';
import { parserarErroresAPI } from '../../utilidades';

@Component({
  selector: 'app-select-distribucion',
  templateUrl: './select-distribucion.component.html',
  styleUrls: ['./select-distribucion.component.css'],
})
export class SelectDistribucionComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    public distribucionService: DistribucionService
  ) {}
  @Input()
  form: FormGroup = this.formBuilder.group({});
  @Input()
  propiedad: string;
  @Input()
  validaciones: any;
  errores: string[] = [];
  distribuciones;

  ngOnInit(): void {
    this.cargarDistribuciones();
  }

  cargarDistribuciones() {
    this.distribucionService.obtenerDistribuciones().subscribe(
      (result) => {
        this.distribuciones = result.result;
      },
      (error) => {
        this.errores = parserarErroresAPI(error);
        this.distribuciones = [];
      }
    );
  }
}
