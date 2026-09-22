import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pasajero, PasajeroDto } from '../models/pasajero.model';


@Injectable({
  providedIn: 'root'
})
export class PasajeroService {
  private readonly apiUrl = 'http://localhost:5149/api/pasajeros';

  constructor(private http: HttpClient) { }

  getPasajeros(): Observable<Pasajero[]> {
    return this.http.get<Pasajero[]>(this.apiUrl);
  }

  getPasajero(id: number): Observable<Pasajero> {
    return this.http.get<Pasajero>(`${this.apiUrl}/${id}`);
  }

  createPasajero(dto: PasajeroDto): Observable<Pasajero> {
    return this.http.post<Pasajero>(this.apiUrl, dto);
  }

  updatePasajero(id: number, dto: PasajeroDto): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, dto);
  }

  deletePasajero(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}