import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EstadoReserva } from '../models/estado-reserva.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EstadoReservaService {
  private apiUrl = `${environment.apiUrl}/estados-reserva`;

  constructor(private http: HttpClient) { }

  getEstadosReserva(): Observable<EstadoReserva[]> {
    return this.http.get<EstadoReserva[]>(this.apiUrl);
  }
}