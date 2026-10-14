import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ReservaService } from '../../services/reserva.service';
import { PasajeroService } from '../../services/pasajero.service';
import { PaqueteService } from '../../services/paquete.service';
import { EstadoReservaService } from '../../services/estado-reserva.service';
import { Pasajero } from '../../models/pasajero.model';
import { Paquete } from '../../models/paquete.model';
import { EstadoReserva } from '../../models/estado-reserva.model';

@Component({
  selector: 'app-reserva-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './reserva-form.component.html',
  styleUrl: './reserva-form.component.css'
})
export class ReservaFormComponent implements OnInit {
  form: FormGroup;
  pasajeros: Pasajero[] = [];
  paquetes: Paquete[] = [];
  estadosReserva: EstadoReserva[] = [];

  constructor(
    private fb: FormBuilder,
    private reservaService: ReservaService,
    private pasajeroService: PasajeroService,
    private paqueteService: PaqueteService,
    private estadoReservaService: EstadoReservaService,
    private router: Router
  ) {
    this.form = this.fb.group({
      idPasajero: [null, Validators.required],
      idPaquete: [null, Validators.required],
      idEstadoReserva: [null, Validators.required],
      cantidadPersonas: [0, [Validators.required, Validators.min(0)]],
      montoAcordado: [null]
    });
  }

  ngOnInit(): void {
    this.pasajeroService.getPasajeros().subscribe({
      next: (data) => { this.pasajeros = data; },
      error: (err) => { console.error('Error al cargar pasajeros', err); }
    });

    this.paqueteService.getPaquetes().subscribe({
      next: (data) => { this.paquetes = data; },
      error: (err) => { console.error('Error al cargar paquetes', err); }
    });

    this.estadoReservaService.getEstadosReserva().subscribe({
      next: (data) => {
        this.estadosReserva = data;
        const consultado = data.find(e => e.nombreEstado === 'Consultado');
        if (consultado) {
          this.form.patchValue({ idEstadoReserva: consultado.idEstadoReserva });
        }
      },
      error: (err) => { console.error('Error al cargar estados de reserva', err); }
    });
  }

  guardar(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    this.reservaService.createReserva(this.form.value).subscribe({
      next: () => { this.router.navigate(['/reservas']); },
      error: (err) => { console.error('Error al guardar reserva', err); }
    });
  }
}