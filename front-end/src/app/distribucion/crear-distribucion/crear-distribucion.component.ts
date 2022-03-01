import { identifierModuleUrl } from '@angular/compiler';
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

  piso0: fila[] = [];
  piso1: fila[] = [];
  pisoSelecctionado: number = 0;
  quitarFila: boolean = false

  estiloEliminarFila: string = 'cursor:pointer'
  valoresEstados = Object.values(this.estadosCeldas).filter((item) => item != -1)
  constructor() { }

  ngOnInit(): void {
    this.crearFila(1)
  }

  cambiarPiso(piso: number) {
    this.pisoSelecctionado = piso
  }

  crearFila(piso: number) {
    var celdas: cell[] = []
    for (var x = 0; x < 5; x++) {
      if (x != 2) {
        celdas.push({ value: this.estadosCeldas.ESPACIO_BUTACA_SEMICAMA, isSelected: false })
      }
      else {
        celdas.push({ value: this.estadosCeldas.ESPACIO_PASILLO, isSelected: false })
      }
    }
    var fila: fila = { planta: piso, cells: celdas }
    if (this.pisoSelecctionado == 0) {
      this.piso0.push(fila);
    }
    else {
      this.piso1.push(fila);
    }
  }

  devolverIconoCelda(value: number, celda: boolean) {
    return this.distribucion.devolverIcono(value, celda)
  }

  devolverTextiToolTips(value: number) {
    return this.distribucion.devolverDescripcion(value)
  }

  seleccionarCelda(celda: number, filaSeleccionada: number) {
    var filaSel: fila;
    if (!this.quitarFila) {
      if (this.pisoSelecctionado == 0) {
        this.piso0[filaSeleccionada].cells[celda].isSelected = !this.piso0[filaSeleccionada].cells[celda].isSelected
      }
      else {
        this.piso1[filaSeleccionada].cells[celda].isSelected = !this.piso1[filaSeleccionada].cells[celda].isSelected
      }

    }
    else {
      if (this.pisoSelecctionado == 0) {
        this.piso0.splice(filaSeleccionada, 1)
      }
      else {
        this.piso1.splice(filaSeleccionada, 1)
      }
    }
  }

  seleccionarDeseleccionarTodo(selected: boolean) {
    if (this.pisoSelecctionado == 0) {
      this.piso0.map((fila) => {
        fila.cells.map((celda, index) => {
          fila.cells[index].isSelected = selected;
        })
      })
    }
    else {
      this.piso1.map((fila) => {
        fila.cells.map((celda, index) => {
          fila.cells[index].isSelected = selected;
        })
      })
    }
  }

  eliminarFila(quitar: boolean) {
    this.quitarFila = quitar;
    if (quitar) {
      this.seleccionarDeseleccionarTodo(false)
      this.estiloEliminarFila = 'cursor:no-drop'
    }
    else {
      this.estiloEliminarFila = 'cursor:pointer'
      document.getElementById("quitarFila").blur()
    }
  }

  cambiarEstado(piso: number, estado: number) {
    if (this.pisoSelecctionado == 0) {
      this.piso0.map((fila) => {
        fila.cells.map((celda, index) => {
          if (fila.cells[index].isSelected) {
            fila.cells[index].value = estado;
          }
        })
      })
    }
    else {
      this.piso1.map((fila) => {
        fila.cells.map((celda, index) => {
          if (fila.cells[index].isSelected) {
            fila.cells[index].value = estado;
          }
        })
      })
    }
  }
}
