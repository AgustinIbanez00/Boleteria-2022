import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { ComprarBoletoComponent } from '../boleteria/comprar-boleto/comprar-boleto.component';
import { ParadasService } from '../paradas/paradas.service';
import { paradasDTO } from '../paradas/paradasDTO';
import { parserarErroresAPI } from '../utilidades/utilidades';
import { webResultList } from '../utilidades/webResult';
import { filtrarViajes, viajeClienteDTO, viajeDTO } from '../viajes/viajaeDTO';
import { ViajesService } from '../viajes/viajes.service';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {
  destinosDTO: viajeClienteDTO[] = []
  errores: string[] = []
  isLoading: boolean = false;
  form: FormGroup;
  paradas: paradasDTO[] = []
  filteredOptionsOrigen: Observable<paradasDTO[]>;
  filteredOptionsDestino: Observable<paradasDTO[]>;
  controlOrigen = new FormControl()
  controlDestino = new FormControl()
  constructor(
    private servicioParadas: ParadasService,
    private formBuilder: FormBuilder,
    private viajesService: ViajesService,
    public dialog: MatDialog,) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      OrigenId: ['', { validators: [Validators.required] }],
      DestinoId: ['', { validators: [Validators.required] }],
      Fecha: ['', { validators: [Validators.required] }]
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
          this.paradas = Object.values(respuesta.body)[1];
        },
        (error) => {
          this.errores = parserarErroresAPI(error);
          this.paradas = [];
        }
      );
  }
  opcionSelectedOrigen(event: MatAutocompleteSelectedEvent) {
    const origen = this.paradas.find((item) => item.descripcion === event.option.value)
    this.form.get('OrigenId').setValue(origen.id)
  }
  opcionSelectedDestino(event: MatAutocompleteSelectedEvent) {
    const origen = this.paradas.find((item) => item.descripcion === event.option.value)
    this.form.get('DestinoId').setValue(origen.id)
  }

  verViaje(idViaje: number) {
    const dialogRef = this.dialog.open(ComprarBoletoComponent, {
      width: '600px',
      data: idViaje,
    });
  }

  buscarViajes(filtroViaje: filtrarViajes) {
    this.isLoading = true;
    this.viajesService.obtenerDestinos(filtroViaje).subscribe((result) => {
      console.log(Object.values(result.body))
      this.destinosDTO = result.body.result as viajeClienteDTO[];

      console.log("destinos changed", this.destinosDTO)
      this.isLoading = false;
    }, (error) => { this.errores = parserarErroresAPI(error); this.isLoading = false; })
  }
}
