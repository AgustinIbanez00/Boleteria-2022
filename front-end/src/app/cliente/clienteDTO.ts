export interface clienteDTO {
  nombre: string;
  estado: number;
  fecha_nacimiento: Date;
  genero: number;
  dni: number;
}

export interface clienteFiltroDTO {
  nombre?: string;
  dni?: number;

  estado?: number;
}
