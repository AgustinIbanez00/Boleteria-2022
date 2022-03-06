import { EnumDiasSemana } from '../utilidades/EnumDiasSemana';

export interface viajeDTO {
  id: number;
  nombre: string;
  estado: number;
  horarios: horarioDTO[];
  conexiones: conexionDTO[];
}

export interface filtrarViajes {
  OrigenId: number;
  DestinoId: number;
  Fecha: Date;
}
export interface viajeFiltroDTO {
  id?: number;
  nombre?: string;
  estado?: number;
}

export interface horarioDTO {
  hora: string;
  dias: EnumDiasSemana[];
  distribucion_id: number;
  id?: number;
}

export interface conexionDTO {
  id: number;
  viaje_id: number;
  origen_id: number;
  destino_id: number;
  precio: number;
  demora: string;
}
