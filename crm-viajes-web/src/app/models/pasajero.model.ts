export interface Pasajero {
  idPasajero: number;
  nombre: string;
  apellido: string;
  dni: string;
  email: string;
  telefono?: string;
  fechaAlta: string;
}

export interface PasajeroDto {
  nombre: string;
  apellido: string;
  dni: string;
  email: string;
  telefono?: string;
}