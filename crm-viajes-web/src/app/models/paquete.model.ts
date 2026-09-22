export interface Paquete {
  idPaquete: number;
  idDestino: number;
  nombre: string;
  fechaSalida: string;
  fechaRegreso: string;
  precioBase: number;
  descripcion?: string;
}

export interface PaqueteDto {
  idDestino: number;
  nombre: string;
  fechaSalida: string;
  fechaRegreso: string;
  precioBase: number;
  descripcion?: string;
}