import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Pasajero } from '../../models/pasajero.model';
import { Reserva } from '../../models/reserva.model';
import { PasajeroService } from '../../services/pasajero.service';
import { ReservaService } from '../../services/reserva.service';

@Component({
  selector: 'app-pasajero-ficha',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './pasajero-ficha.component.html',
  styleUrl: './pasajero-ficha.component.css'
})
export class PasajeroFichaComponent implements OnInit {
  pasajero?: Pasajero;
  reservas: Reserva[] = [];

  constructor(
    private route: ActivatedRoute,
    private pasajeroService: PasajeroService,
    private reservaService: ReservaService
  ) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.pasajeroService.getPasajero(id).subscribe({
      next: (data) => { this.pasajero = data; },
      error: (err) => { console.error('Error al cargar el pasajero', err); }
    });

    this.reservaService.getReservas().subscribe({
      next: (data) => { this.reservas = data.filter(r => r.idPasajero === id); },
      error: (err) => { console.error('Error al cargar las reservas', err); }
    });
  }
}