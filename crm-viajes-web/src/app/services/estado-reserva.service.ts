import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EstadoReserva } from '../models/estado-reserva.model';

@Injectable({
  providedIn: 'root'
})
export class EstadoReservaService {
  private apiUrl = 'http://localhost:5149/api/estados-reserva';

  constructor(private http: HttpClient) { }

  getEstadosReserva(): Observable<EstadoReserva[]> {
    return this.http.get<EstadoReserva[]>(this.apiUrl);
  }
}