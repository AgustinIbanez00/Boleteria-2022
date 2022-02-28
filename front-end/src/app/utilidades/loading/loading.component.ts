import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.css']
})
export class LoadingComponent implements OnInit {

  constructor(
  ) { }
  @Input()
  mensaje: string = "Cargando";
  @Input()
  isLoading: boolean = false;
  ngOnInit(): void {
  }


}
