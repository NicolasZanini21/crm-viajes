import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Continente } from '../models/continente.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ContinenteService {
  private apiUrl = `${environment.apiUrl}/continentes`;

  constructor(private http: HttpClient) { }

  getContinentes(): Observable<Continente[]> {
    return this.http.get<Continente[]>(this.apiUrl);
  }
}