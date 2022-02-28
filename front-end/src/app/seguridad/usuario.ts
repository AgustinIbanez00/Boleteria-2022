export interface registroDTO {
    email: string,
    password: string,
    confirm_password: string,
    first_name: string,
    last_name: string,
    dni: string,
    fecha_nacimiento: Date
}

export interface loginDTO {
    email: string;
    password: string;
}

export interface usuarioDTO {
    dni: string;
    email: string;
    tipo: number;
    nombre: string;
    apellido: string;
}