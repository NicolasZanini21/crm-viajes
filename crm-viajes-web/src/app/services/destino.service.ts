import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Destino, DestinoDto } from '../models/destino.model';

@Injectable({
  providedIn: 'root'
})
export class DestinoService {
  private readonly apiUrl = 'http://localhost:5149/api/destinos';

  constructor(private http: HttpClient) { }

  getDestinos(): Observable<Destino[]> {
    return this.http.get<Destino[]>(this.apiUrl);
  }

  getDestino(id: number): Observable<Destino> {
    return this.http.get<Destino>(`${this.apiUrl}/${id}`);
  }

  createDestino(dto: DestinoDto): Observable<Destino> {
    return this.http.post<Destino>(this.apiUrl, dto);
  }

  updateDestino(id: number, dto: DestinoDto): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, dto);
  }

  deleteDestino(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}