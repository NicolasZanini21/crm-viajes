import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Paquete, PaqueteDto } from '../models/paquete.model';

@Injectable({
  providedIn: 'root'
})
export class PaqueteService {
  private readonly apiUrl = 'http://localhost:5149/api/paquetes';

  constructor(private http: HttpClient) { }

  getPaquetes(): Observable<Paquete[]> {
    return this.http.get<Paquete[]>(this.apiUrl);
  }

  getPaquete(id: number): Observable<Paquete> {
    return this.http.get<Paquete>(`${this.apiUrl}/${id}`);
  }

  createPaquete(dto: PaqueteDto): Observable<Paquete> {
    return this.http.post<Paquete>(this.apiUrl, dto);
  }

  updatePaquete(id: number, dto: PaqueteDto): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, dto);
  }

  deletePaquete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}