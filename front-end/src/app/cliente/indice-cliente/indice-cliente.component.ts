import { HttpResponse } from '@angular/common/http';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { MatTable } from '@angular/material/table';
import { ConfirmComponent } from 'src/app/utilidades/confirm/confirm.component';
import { EstadosClientes } from 'src/app/utilidades/estados';
import { NotificacionesService } from 'src/app/utilidades/notificaciones.service';
import { parserarErroresAPI } from 'src/app/utilidades/utilidades';
import { webResult, webResultList } from 'src/app/utilidades/webResult';
import { ClienteService } from '../cliente.service';
import { clienteDTO, clienteFiltroDTO } from '../clienteDTO';
import { CrearClienteComponent } from '../crear-cliente/crear-cliente.component';

@Component({
  selector: 'app-indice-cliente',
  templateUrl: './indice-cliente.component.html',
  styleUrls: ['./indice-cliente.component.css'],
})
export class IndiceClienteComponent implements OnInit {
  constructor(
    public dialog: MatDialog,
    public clienteService: ClienteService,
    private formBuilder: FormBuilder,
    private notificacionesService: NotificacionesService
  ) {}

  @Input()
  clientes;

  dni: number;
  nombre: string;
  estado: number;
  fecha_nacimiento: Date;
  genero: number;
  nacinalidad: string;

  cantidadTotalRegistros;
  paginaActual = 1;
  cantidadRegistrosAMostrar = 10;
  errores: string[] = [];
  estadosCliente = Object.entries(new EstadosClientes());
  isChecked = true;
  clientesCole: clienteDTO[] = [];

  form: FormGroup;

  columnasAMostrar = [
    'dni',
    'nombre',
    'estado',

    'editar',
    'eliminar',
    'habilitar',
  ];

  clienteFiltroDTO: clienteFiltroDTO = {
    estado: null,
    nombre: null,
    dni: null,
  };

  //agarrar referencia de la tabla
  @ViewChild(MatTable) table: MatTable<any>;

  ngOnInit(): void {
    this.obtenerCliente(this.paginaActual, this.cantidadRegistrosAMostrar),
      (this.form = this.formBuilder.group({
        nombre: [
          '',
          { validators: [Validators.required, Validators.maxLength(100)] },
        ],
        dni: [
          '',
          {
            validators: [
              Validators.required,
              Validators.maxLength(8),
              Validators.minLength(8),
            ],
          },
        ],
        fecha_nacimiento: ['', { validators: [Validators.required] }],
        genero: ['', { validators: [Validators.required] }],
        estado: 0,
      }));

    this.cargarRegistrosFiltrados(
      this.clienteFiltroDTO,
      this.paginaActual,
      this.cantidadRegistrosAMostrar
    );
  }

  openDialogCliente(id: number) {
    let dialogRef;
    if (id === null) {
      dialogRef = this.dialog.open(CrearClienteComponent, {
        width: '600px',
        data: {
          dni: this.dni,
          nombre: this.nombre,
          fecha_nacimiento: this.fecha_nacimiento,
          genero: this.genero,
          nacinalidad: this.nacinalidad,
        },
      });
    } else {
      const cliente = this.clientes.find((it) => it.id === id);

      dialogRef = this.dialog.open(CrearClienteComponent, {
        width: '600px',
        data: cliente,
      });
    }

    dialogRef.beforeClosed().subscribe((result) => {
      this.obtenerCliente(this.paginaActual, this.cantidadRegistrosAMostrar);
    });
  }

  refreshClientes(pagina: number, cantidadRegistrosAMostrar: number) {
    this.clientes = null;
    this.obtenerCliente(this.paginaActual, this.cantidadRegistrosAMostrar);
  }

  // listado
  obtenerCliente(pagina: number, cantidadRegistrosAMostrar: number) {
    this.clienteService
      .obtenerClientes(pagina, cantidadRegistrosAMostrar)
      .subscribe(
        (respuesta: HttpResponse<webResultList>) => {
          this.clientes = Object.values(respuesta.body.result);

          this.cantidadTotalRegistros = respuesta.body.pagination.total_items;
        },
        (error) => {
          this.errores = parserarErroresAPI(error);
          this.clientes = [];
        }
      );
  }

  // paginacion
  actualizarPaginacion(datos: PageEvent) {
    this.paginaActual = datos.pageIndex + 1;
    this.cantidadRegistrosAMostrar = datos.pageSize;

    this.cargarRegistrosFiltrados(
      this.clienteFiltroDTO,
      this.paginaActual,
      this.cantidadRegistrosAMostrar
    );
  }

  filtrar(clienteFiltroDTO: clienteFiltroDTO) {
    this.paginaActual = 1;
    this.cargarRegistrosFiltrados(
      clienteFiltroDTO,
      this.paginaActual,
      this.cantidadRegistrosAMostrar
    );
  }

  // filtro
  cargarRegistrosFiltrados(
    clienteFiltroDTO: clienteFiltroDTO,
    pagina: number,
    cantidadRegistrosAMostrar: number
  ) {
    this.clienteService
      .filtrarClientes(clienteFiltroDTO, pagina, cantidadRegistrosAMostrar)
      .subscribe(
        (respuesta: HttpResponse<webResultList>) => {
          this.clientes = Object.values(respuesta.body.result);

          this.cantidadTotalRegistros = respuesta.body.pagination.total_items;
        },
        (error) => {
          this.errores = parserarErroresAPI(error);
        }
      );
  }

  hablitarDeshabilitar(event, cliente: clienteDTO) {
    cliente.estado = event.checked ? 1 : 0;
    this.editar(cliente);
  }

  //editar
  editar(clienteDTO: clienteDTO) {
    this.clienteService.editar(clienteDTO).subscribe(
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

  devolverEstado(estado: number) {
    return this.estadosCliente.filter((items) => {
      return items[1] == estado;
    })[0][0];
  }

  //eliminar
  eliminar(clienteDTO: clienteDTO) {
    this.clienteService.eliminar(clienteDTO).subscribe(
      (result) => {
        if (result.body.success) {
          this.notificacionesService.showNotificacion(
            result.body.message,
            'x',
            'success'
          );
          this.obtenerCliente(
            this.paginaActual,
            this.cantidadRegistrosAMostrar
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

  openDialogEliminar(clienteDTO: clienteDTO) {
    const dialogRef = this.dialog.open(ConfirmComponent, {
      width: '300px',
      data: {
        mensaje: '¿Desea eliminar permanentemente este registro?',
      },
    });

    dialogRef.beforeClosed().subscribe((result) => {
      result ? this.eliminar(clienteDTO) : null;
    });
  }
}
