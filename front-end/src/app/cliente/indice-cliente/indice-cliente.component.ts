import { HttpResponse } from '@angular/common/http';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { MatTable } from '@angular/material/table';
import { CrearParadasComponent } from 'src/app/paradas/crear-paradas/crear-paradas.component';
import { ConfirmComponent } from 'src/app/utilidades/confirm/confirm.component';
import { EstadosClientes } from 'src/app/utilidades/estados';
import { NotificacionesService } from 'src/app/utilidades/notificaciones.service';
import { parserarErroresAPI } from 'src/app/utilidades/utilidades';
import { webResult } from 'src/app/utilidades/webResult';
import { ClienteService } from '../cliente.service';
import { clienteDTO } from '../clienteDTO';
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

  id: number;
  nombre: string;
  // estado: number;
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
    // 'estado',
    'dni',
    'nombre',
    'editar',
    'eliminar',
    'habilitar',
  ];

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
        fechaNacimiento: ['', { validators: [Validators.required] }],
        nacionalidad: ['', { validators: [Validators.required] }],
        genero: ['', { validators: [Validators.required] }],
        estado: 0,
      }));

    this.form.valueChanges.subscribe((valores) => {
      this.cargarRegistrosFiltrados(
        valores,
        this.paginaActual,
        this.cantidadRegistrosAMostrar
      );
    });
  }

  openDialogCliente(id: number) {
    var dialogRef;
    if (id === null) {
      dialogRef = this.dialog.open(CrearClienteComponent, {
        width: '800px',
        data: {
          id: this.id,
          nombre: this.nombre,
        },
      });
    } else {
      var parada = this.clientes.find((it) => it.id === id);
      console.log('parada', parada);
      dialogRef = this.dialog.open(CrearClienteComponent, {
        width: '800px',
        data: parada,
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
        (respuesta: HttpResponse<webResult>) => {
          this.clientes = Object.values(respuesta.body.result);
          console.log('respuesta', Object.values(respuesta.headers));
          this.clientes = Object.values(respuesta.body.result);
          this.cantidadTotalRegistros = respuesta.headers.get(
            'cantidadTotalRegistros'
          );
        },
        (error) => {
          this.errores = parserarErroresAPI(error);
        }
      );
  }

  // paginacion
  actualizarPaginacion(datos: PageEvent) {
    this.paginaActual = datos.pageIndex + 1;
    this.cantidadRegistrosAMostrar = datos.pageSize;
    // this.cargarRegistrosFiltrados(
    //   this.form.value,
    //   this.paginaActual,
    //   this.cantidadRegistrosAMostrar
    // );
  }

  // filtro
  cargarRegistrosFiltrados(
    valores: any,
    pagina: number,
    cantidadRegistrosAMostrar: number
  ) {
    // valores.pagina = pagina;
    // valores.recordsPorPagina = cantidadRegistrosAMostrar;
    // this.productoService.filtrarMisProductos(valores).subscribe(
    //   (respuesta: HttpResponse<webResult>) => {
    //     if (respuesta.body.success) {
    //       this.misProductos = Object.values(respuesta.body.data);
    //       this.cantidadTotalRegistros = respuesta.headers.get(
    //         'cantidadTotalRegistros'
    //       );
    //     } else {
    //       if (
    //         respuesta.body.errorList &&
    //         respuesta.body.errorList.length != 0
    //       ) {
    //         this.errores.push(...respuesta.body.errorList);
    //       } else {
    //         this.errores.push(respuesta.body.error);
    //       }
    //     }
    //   },
    //   (error) => {
    //     this.errores = parserarErroresAPI(error);
    //   }
    //);
  }

  hablitarDeshabilitar(event, cliente: clienteDTO) {
    //  cliente.estado = event.checked ? 1 : 0;
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
        }
      },
      (errorResult) => {
        console.log('estocode', errorResult);

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
        console.log(result);
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
        console.log('estocode', errorResult);

        this.notificacionesService.showNotificacion(
          errorResult.error.message,
          'x',
          'error'
        );
      }
    );
  }
  openDialogEliminar(clienteDTO: clienteDTO) {
    var dialogRef = this.dialog.open(ConfirmComponent, {
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
