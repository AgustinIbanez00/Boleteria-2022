import { Component, OnInit } from '@angular/core';
import { Distribucion, fila, cell, EstadosCeldas } from '../distribucionDTO';


@Component({
  selector: 'app-crear-distribucion',
  templateUrl: './crear-distribucion.component.html',
  styleUrls: ['./crear-distribucion.component.css']
})
export class CrearDistribucionComponent implements OnInit {

  distribucion: Distribucion = new Distribucion();
  estadosCeldas: EstadosCeldas = new EstadosCeldas();

  piso1: fila[] = [];
  constructor() { }

  ngOnInit(): void {
    this.piso1.push(this.crearFila(1))
    this.piso1.push(this.crearFila(1))
  }

  crearFila(piso: number) {
    var celdas: cell[] = []
    for (var x = 0; x < 5; x++) {
      if (x != 2) {
        celdas.push({ value: this.estadosCeldas.ESPACIO_BUTACA_SEMICAMA })
      }
      else {
        celdas.push({ value: this.estadosCeldas.ESPACIO_PASILLO })
      }
    }


    var fila: fila = { planta: piso, cells: celdas }
    console.log(fila)
    return fila;
  }

  devolverIconoCelda(value: number) {
    switch (value) {
      case this.estadosCeldas.ESPACIO_BUTACA: return "Butaca";
      case this.estadosCeldas.ESPACIO_PASILLO: return "Pasillo";
      case this.estadosCeldas.ESPACIO_TV: return "TV";
      // case this.estadosCeldas.es: return "Pasillo";
    }
  }

}
