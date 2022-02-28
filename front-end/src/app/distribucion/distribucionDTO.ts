export class Distribucion {
  filas: fila[];
  nota: string = '';
  un_piso: boolean = false;
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
}




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