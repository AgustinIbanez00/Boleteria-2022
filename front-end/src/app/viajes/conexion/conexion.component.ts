import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ParadasService } from 'src/app/paradas/paradas.service';
import { parserarErroresAPI } from 'src/app/utilidades/utilidades';
import { conexionDTO, viajeDTO } from '../viajaeDTO';

@Component({
  selector: 'app-conexion',
  templateUrl: './conexion.component.html',
  styleUrls: ['./conexion.component.css'],
})
export class ConexionComponent implements OnInit {
  @Output()
  cargarConexion: EventEmitter<conexionDTO> = new EventEmitter<conexionDTO>();

  @Input()
  viajeDTO: viajeDTO;

  conexionForm: FormGroup;
  paradas;
  errores: string[] = [];

  constructor(
    public paradasService: ParadasService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.conexionForm = this.formBuilder.group({
      viaje_id: this.viajeDTO ? this.viajeDTO.id : '',
      origen_id: ['', { validators: [Validators.required] }],
      destino_id: '',
      precio: ['', { validators: [Validators.required] }],
      demora: ['', { validators: [Validators.required] }],
    });

    this.buscarParadas();
  }
  cont = 1;
  guardarConexion(conexion: conexionDTO) {
    var conexion: conexionDTO = JSON.parse(JSON.stringify(conexion));
    const con = conexion;
    console.log(this.cont);
    if (this.cont != 1) {
      conexion.destino_id = con.origen_id;
    }
    conexion.viaje_id = this.viajeDTO.id;
    this.cont++;
    console.log(conexion);
    this.cargarConexion.emit(conexion);
  }

  // --------- PARADAS -------------

  buscarParadas() {
    this.paradasService.obtenerListParadas().subscribe(
      (result) => {
        this.paradas = result.body.result;
      },
      (error) => {
        this.errores = parserarErroresAPI(error);
      }
    );
  }
}
