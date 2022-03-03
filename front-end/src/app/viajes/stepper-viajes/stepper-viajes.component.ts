import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { STEPPER_GLOBAL_OPTIONS } from '@angular/cdk/stepper';
import { conexionDTO, horarioDTO, viajeDTO } from '../viajaeDTO';
import { ViajesService } from '../viajes.service';
import { NotificacionesService } from 'src/app/utilidades/notificaciones.service';

import { EnumDiasSemana } from 'src/app/utilidades/EnumDiasSemana';
import { DistribucionService } from 'src/app/distribucion/distribucion.service';
import { distribucionDTO } from 'src/app/distribucion/distribucionDTO';
import { parserarErroresAPI } from 'src/app/utilidades/utilidades';

import { ActivatedRoute, Router } from '@angular/router';
import { ParadasService } from 'src/app/paradas/paradas.service';
import { NodosService } from '../nodos.service';

@Component({
  selector: 'app-stepper-viajes',
  templateUrl: './stepper-viajes.component.html',
  styleUrls: ['./stepper-viajes.component.css'],
  providers: [
    {
      provide: STEPPER_GLOBAL_OPTIONS,
      useValue: { showError: true },
    },
  ],
})
export class StepperViajesComponent implements OnInit {
  viajeDistribucionForm: FormGroup;
  viajeHorarioForm: FormGroup;
  viajeConexionForm: FormGroup;
  paradasForm: FormGroup;

  checked = false;
  constructor(
    private formBuilder: FormBuilder,
    public viajesService: ViajesService,
    private notificacionesService: NotificacionesService,
    public distribucionService: DistribucionService,
    public paradasService: ParadasService,
    public nodosService: NodosService,
    private router: Router
  ) {}

  @Input()
  viajeDTO: viajeDTO;

  listHorarios: horarioDTO[] = [];

  listConexiones: conexionDTO[] = [];

  listDiasSemana: { descripcion: string; value: number }[] = [];
  distribuciones;
  viajes;
  errores: string[] = [];
  isEditar: boolean = false;
  isViajeCompleto = false;

  paradas;
  ngOnInit(): void {
    this.buscarParadas();
    this.viajeDistribucionForm = this.formBuilder.group({
      nombre: [
        '',
        { validators: [Validators.required, Validators.maxLength(100)] },
      ],
    });
    this.viajeHorarioForm = this.formBuilder.group({
      horarios: [, { validators: [Validators.required] }],
    });
    this.cargarDistribuciones();

    this.viajeConexionForm = this.formBuilder.group({
      viaje_id: [
        this.viajeDTO ? this.viajeDTO.id : '',
        { validators: [Validators.required] },
      ],
      origen_id: ['', { validators: [Validators.required] }],
      destino_id: ['', { validators: [Validators.required] }],
      precio: ['', { validators: [Validators.required] }],
      demora: ['', { validators: [Validators.required] }],
    });
    console.log('viaje por que estoy editando', this.viajeDTO);
    if (this.viajeDTO) {
      this.isEditar = true;
      this.viajeDistribucionForm.patchValue(this.viajeDTO);
      this.viajeHorarioForm.patchValue(this.viajeDTO);

      this.listHorarios = this.viajeDTO.horarios;
      if (this.viajeDTO.conexiones) {
        console.log('conexiones porque estoy editando', this.listConexiones);
        this.listConexiones.push(...this.viajeDTO.conexiones);
      }
    }

    this.paradasForm = this.formBuilder.group({
      nombre: [
        '',
        { validators: [Validators.required, Validators.maxLength(100)] },
      ],
      pais_id: ['', { validators: [Validators.required] }],
      provincia_id: ['', { validators: [Validators.required] }],
    });
  }

  public validacionesD(propiedad: string) {
    var campo = this.viajeDistribucionForm.get(propiedad);

    if (campo.hasError('required')) {
      return 'Campo ' + propiedad + ' requerido';
    } else if (campo.hasError('maxlength')) {
      return 'El minimo son 100 caracteres';
    }

    return '';
  }

  public validacionesHorarios(propiedad: string) {
    var campo = this.viajeHorarioForm.get(propiedad);

    if (campo.hasError('required')) {
      return 'Campo ' + propiedad + ' requerido';
    }
  }

  // ---------- HORARIOS ----------

  agregarHorario(horario: horarioDTO) {
    this.listHorarios.push(horario);
  }

  obtenerDescripcionDias(dias: EnumDiasSemana[]) {
    let valoresDiasSemana = Object.keys(EnumDiasSemana)
      .map((key) => EnumDiasSemana[key])
      .filter((value) => typeof value === 'string') as string[];

    return dias.map((item) => ' ' + valoresDiasSemana[item]);
  }

  eliminarHorario(index: number) {
    this.listHorarios.splice(index, 1);
  }

  // ---------- DISTRIBUCION -----------

  async cargarDistribuciones() {
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

  obtenerDistribucion(distribucion_id: number) {
    if (this.distribuciones) {
      var distribucion = this.distribuciones.find(
        (it) => it.id === distribucion_id
      );
      // console.log(distribucion);
      return distribucion.nota;
    }
  }

  // --------- VIAJE ----------------

  // guardar
  guardarViajes(guardarFinal: boolean) {
    if (!this.isEditar) {
      this.viajeDTO = {
        ...this.viajeDistribucionForm.value,
      };

      this.viajeDTO.horarios = this.listHorarios;
      console.log('aca');
      this.viajeDTO.conexiones = this.listConexiones;
      this.crear(this.viajeDTO, guardarFinal);
    } else {
      this.editar(this.viajeDTO, guardarFinal);
    }
  }

  crear(viajeDTO: viajeDTO, guardarFinal: boolean) {
    console.log(viajeDTO);
    this.viajesService.crear(viajeDTO).subscribe(
      (result) => {
        if (result.body.success) {
          this.viajeHorarioForm.get('horarios').setValue(viajeDTO.horarios);

          this.viajeDTO = result.body.result as viajeDTO;
          console.log('aca 2', viajeDTO);
          if (guardarFinal) {
            this.notificacionesService.showNotificacion(
              result.body.message,
              'x',
              'success'
            );
            this.router.navigate(['/viajes']);
          }
        } else {
          this.notificacionesService.showNotificacion(
            result.body.message,
            'x',
            'error'
          );
        }
      },
      (errorResult) => {
        this.notificacionesService.showNotificacion(
          errorResult.error.message,
          'x',
          'error'
        );
      }
    );
  }

  editar(viajeDTO: viajeDTO, guardarFinal: boolean) {
    console.log(viajeDTO);
    this.viajesService.editar(viajeDTO).subscribe(
      (result) => {
        if (result.body.success) {
          this.viajeHorarioForm.get('horarios').setValue(viajeDTO.horarios);

          this.viajeDTO = result.body.result as viajeDTO;
          console.log('aca 2', viajeDTO);
          if (guardarFinal) {
            this.notificacionesService.showNotificacion(
              result.body.message,
              'x',
              'success'
            );
            this.router.navigate(['/viajes']);
          }
        } else {
          this.notificacionesService.showNotificacion(
            result.body.message,
            'x',
            'error'
          );
        }
      },
      (errorResult) => {
        this.notificacionesService.showNotificacion(
          errorResult.error.message,
          'x',
          'error'
        );
      }
    );
  }

  // -------- CONEXION ----------------

  agregarConexion(conexion: conexionDTO) {
    var con = conexion;
    if (this.listConexiones.length == 0) {
      conexion.destino_id = con.origen_id;
    } else {
      let ultimaConexion = this.listConexiones[this.listConexiones.length - 1];
      conexion.origen_id = ultimaConexion.destino_id;
    }

    this.listConexiones.push(conexion);
    this.isViajeCompleto = true;
  }

  borrarConexiones() {
    this.listConexiones = [];
  }

  guardarConexion(conexion) {
    console.log(conexion.value);

    this.nodosService.crear(conexion.value).subscribe(
      (result) => {
        if (result.body.success) {
          this.notificacionesService.showNotificacion(
            result.body.message,
            'x',
            'success'
          );
        } else {
          this.notificacionesService.showNotificacion(
            result.body.message,
            'x',
            'error'
          );
        }
      },
      (errorResult) => {
        this.notificacionesService.showNotificacion(
          errorResult.error.message,
          'x',
          'error'
        );
      }
    );
  }

  // --------- PARADAS --------

  buscarParadas() {
    this.paradasService.obtenerListParadas().subscribe(
      (result) => {
        this.paradas = result.body.result;
        console.log('paradas luci', this.paradas);
      },
      (error) => {
        this.errores = parserarErroresAPI(error);
      }
    );
  }

  buscarParaPorId(id: number) {
    var parada = this.paradas.find((it) => it.id === id);
    return parada;
  }
}
