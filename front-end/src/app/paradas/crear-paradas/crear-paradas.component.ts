import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { paradasDTO } from '../paradasDTO';
import { ParadasService } from '../paradas.service';

@Component({
  selector: 'app-crear-paradas',
  templateUrl: './crear-paradas.component.html',
  styleUrls: ['./crear-paradas.component.css'],
})
export class CrearParadasComponent implements OnInit {
  constructor(public paradaraService: ParadasService) {}

  error_messages: Map<string, string[]> = new Map<string, string[]>();
  form: FormGroup;
  dto: paradasDTO;

  ngOnInit(): void {
    this.dto = { nombre: '', id: 0 };

    this.crear(this.dto);
  }

  // crear
  crear(paradasDTO: paradasDTO) {
    this.paradaraService.crear(paradasDTO).subscribe((result) => {
      console.log('respuest', result);
      this.error_messages = result.error_messages;
      console.log('respuest', this.error_messages);
    });
  }
}
