export interface Reserva {
  idReserva: number;
  idPasajero: number;
  idPaquete: number;
  idEstadoReserva: number;
  cantidadPersonas: number;
  montoAcordado?: number;
  fechaReserva: string;
  fechaUltimaActualizacion: string;
}

export interface ReservaDto {
  idPasajero: number;
  idPaquete: number;
  idEstadoReserva: number;
  cantidadPersonas: number;
  montoAcordado?: number;
}