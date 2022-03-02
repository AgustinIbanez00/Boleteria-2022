import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-listado-generico',
  templateUrl: './listado-generico.component.html',
  styleUrls: ['./listado-generico.component.css'],
})
export class ListadoGenericoComponent implements OnInit {
  constructor() { }

  @Input()
  listado;
  @Input()
  mensajeLoading: string = 'Cargando...';

  @Input()
  esLista: boolean = true;

  ngOnInit(): void {
    console.log(this.esLista)
    console.log(this.listado)
  }
}
