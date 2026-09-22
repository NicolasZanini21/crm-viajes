export interface Destino {
  idDestino: number;
  nombre: string;
  pais: string;
  descripcion?: string;
}

export interface DestinoDto {
  nombre: string;
  pais: string;
  descripcion?: string;
}