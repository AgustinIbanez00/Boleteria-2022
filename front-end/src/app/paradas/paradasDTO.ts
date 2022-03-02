export interface paradasDTO {
  id: number;
  nombre: string;
  estado: number;
  pais_id: number;
  provincia_id: number;
}

export interface paradasFiltroDTO {
  id?: number;
  nombre?: string;
  estado?: number;
  pais_id?: number;
  provincia_id: number;
}
