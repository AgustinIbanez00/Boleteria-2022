
export class EstadosCeldas {
  ESPACIO_NULL: number = -1;
  ESPACIO_PASILLO: number = 1;
  ESPACIO_BUTACA: number = 2;
  ESPACIO_TV: number = 3;
  ESPACIO_BUTACA_NO_DIPOSNIBLE: number = 5;
  ESPACIO_BUTACA_SEMICAMA: number = 6;
  ESPACIO_BUTACA_CAMA: number = 7;
  ESPACIO_ESCALERA: number = 8
}

var estadosCeldas: EstadosCeldas = new EstadosCeldas();
export class Distribucion {
  filas: fila[] = []
  nota: string = '';
  un_piso: boolean = true;
  devolverIcono(value, celda: boolean) {
    switch (value) {
      case estadosCeldas.ESPACIO_BUTACA: return "assets/imagenes/distribucion/butaca.png";
      case estadosCeldas.ESPACIO_PASILLO: if (!celda) { return "assets/imagenes/distribucion/pasillo.png"; }
        return ''
      case estadosCeldas.ESPACIO_TV: return "assets/imagenes/distribucion/tv.png";
      case estadosCeldas.ESPACIO_BUTACA_CAMA: return "assets/imagenes/distribucion/cama.png";
      case estadosCeldas.ESPACIO_BUTACA_SEMICAMA: return "assets/imagenes/distribucion/semi_cama.png";
      case estadosCeldas.ESPACIO_ESCALERA: return "assets/imagenes/distribucion/escalera.png";
      default: return "assets/imagenes/distribucion/no_disponible.png";
    }
  }

  devolverDescripcion(value: number) {
    switch (value) {
      case estadosCeldas.ESPACIO_BUTACA: return "Butaca";
      case estadosCeldas.ESPACIO_PASILLO: return "Pasillo";
      case estadosCeldas.ESPACIO_TV: return "TV";
      case estadosCeldas.ESPACIO_BUTACA_SEMICAMA: return "Semi-Cama";
      case estadosCeldas.ESPACIO_BUTACA_CAMA: return "Cama";
      case estadosCeldas.ESPACIO_ESCALERA: return "Escalera";
      case estadosCeldas.ESPACIO_BUTACA_NO_DIPOSNIBLE: return "No disponible";
    }
  }
}
export class distribucionDTO {
  id: number = -1;
  filas: fila[];
  nota: string = '';
  un_piso: boolean = false;
}

export interface fila {
  cells: cell[];
  planta: number;
}

export interface cell {
  value: number;
  isSelected: boolean;
}




