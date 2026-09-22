import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { Pasajero } from '../../models/pasajero.model';
import { PasajeroService } from '../../services/pasajero.service';

@Component({
  selector: 'app-pasajero-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './pasajero-list.component.html',
  styleUrl: './pasajero-list.component.css'
})
export class PasajeroListComponent implements OnInit {
  pasajeros: Pasajero[] = [];

  constructor(
    private pasajeroService: PasajeroService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.pasajeroService.getPasajeros().subscribe({
      next: (data) => { this.pasajeros = data; },
      error: (err) => { console.error('Error al cargar pasajeros', err); }
    });
  }

  verFicha(id: number): void {
    this.router.navigate(['/pasajeros', id]);
  }
}