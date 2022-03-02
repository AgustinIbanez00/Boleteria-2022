import { Component, EventEmitter, Inject, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { cell, DistribucionDTO, EstadosCeldas, fila } from '../distribucionDTO';

@Component({
  selector: 'app-distribucion',
  templateUrl: './distribucion.component.html',
  styleUrls: ['./distribucion.component.css']
})
export class DistribucionComponent implements OnInit {
  @Input()
  distribucion: DistribucionDTO = new DistribucionDTO();
  @Input()
  readOnly: boolean = true;
  @Output()
  OnSubmit: EventEmitter<DistribucionDTO> = new EventEmitter<DistribucionDTO>();

  estadosCeldas: EstadosCeldas = new EstadosCeldas();
  errores: string[] = []
  piso0: fila[] = [];
  piso1: fila[] = [];
  pisoSelecctionado: number = 0;
  quitarFila: boolean = false
  form: FormGroup
  estiloEliminarFila: string = 'cursor:pointer'
  valoresEstados = Object.values(this.estadosCeldas).filter((item) => item != -1)
  constructor(private formBuilder: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      nota: ['', { validators: [Validators.required] }]
    })
  }


  validacionesFormulario(nombre: string) {
    var campo = this.form.get(nombre);
    if (campo.hasError('required')) {
      return 'Campo requerido';
    }
  }

  cambiarPiso(piso: number) {
    this.pisoSelecctionado = piso
  }

  crearFila(tipo: number) {
    var celdas: cell[] = []
    for (var x = 0; x < 5; x++) {
      if (x != 2) {
        celdas.push({ value: tipo == 6 ? this.estadosCeldas.ESPACIO_BUTACA_SEMICAMA : this.estadosCeldas.ESPACIO_BUTACA, isSelected: false })
      }
      else {
        celdas.push({ value: this.estadosCeldas.ESPACIO_PASILLO, isSelected: false })
      }
    }
    var fila: fila = { planta: this.pisoSelecctionado, cells: celdas }
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
    this.seleccionarDeseleccionarTodo(false)
  }

  guardar() {
    this.distribucion.filas = []
    this.distribucion.filas.push(...this.piso0)
    if (!this.distribucion.un_piso) {
      this.distribucion.filas.push(...this.piso1)
    }
    this.distribucion.nota = this.form.value.nota;

    this.OnSubmit.emit(this.distribucion)
  }
}
