import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { Reserva } from '../../models/reserva.model';
import { Pasajero } from '../../models/pasajero.model';
import { Paquete } from '../../models/paquete.model';
import { EstadoReserva } from '../../models/estado-reserva.model';
import { ReservaService } from '../../services/reserva.service';
import { PasajeroService } from '../../services/pasajero.service';
import { PaqueteService } from '../../services/paquete.service';
import { EstadoReservaService } from '../../services/estado-reserva.service';

@Component({
  selector: 'app-reserva-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './reserva-list.component.html',
  styleUrl: './reserva-list.component.css'
})
export class ReservaListComponent implements OnInit {
  reservas: Reserva[] = [];
  pasajeros: Pasajero[] = [];
  paquetes: Paquete[] = [];
  estadosReserva: EstadoReserva[] = [];

  constructor(
    private reservaService: ReservaService,
    private pasajeroService: PasajeroService,
    private paqueteService: PaqueteService,
    private estadoReservaService: EstadoReservaService
  ) { }

  ngOnInit(): void {
    this.reservaService.getReservas().subscribe({
      next: (data) => { this.reservas = data; },
      error: (err) => { console.error('Error al cargar reservas', err); }
    });

    this.pasajeroService.getPasajeros().subscribe({
      next: (data) => { this.pasajeros = data; },
      error: (err) => { console.error('Error al cargar pasajeros', err); }
    });

    this.paqueteService.getPaquetes().subscribe({
      next: (data) => { this.paquetes = data; },
      error: (err) => { console.error('Error al cargar paquetes', err); }
    });

    this.estadoReservaService.getEstadosReserva().subscribe({
      next: (data) => { this.estadosReserva = data; },
      error: (err) => { console.error('Error al cargar estados de reserva', err); }
    });
  }

  nombrePasajero(id: number): string {
    const pasajero = this.pasajeros.find(p => p.idPasajero === id);
    return pasajero ? `${pasajero.nombre} ${pasajero.apellido}` : '';
  }

  nombrePaquete(id: number): string {
    const paquete = this.paquetes.find(p => p.idPaquete === id);
    return paquete ? paquete.nombre : '';
  }

  nombreEstado(id: number): string {
    const estado = this.estadosReserva.find(e => e.idEstadoReserva === id);
    return estado ? estado.nombreEstado : '';
  }
}