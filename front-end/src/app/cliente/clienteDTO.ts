export interface clienteDTO {
  nombre: string;
  // estado: number;
  fecha_nacimiento: Date;
  genero: number;
  dni: number;
  nacinalidad: string;
}

export interface clienteFiltroDTO {
  nombre?: string;
  dni?: number;
  nacinalidad?: string;
  // estado?: number;
}
