import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PaqueteService } from '../../services/paquete.service';
import { DestinoService } from '../../services/destino.service';
import { Destino } from '../../models/destino.model';

@Component({
  selector: 'app-paquete-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './paquete-form.component.html',
  styleUrl: './paquete-form.component.css'
})
export class PaqueteFormComponent implements OnInit {
  form: FormGroup;
  destinos: Destino[] = [];

  constructor(
    private fb: FormBuilder,
    private paqueteService: PaqueteService,
    private destinoService: DestinoService,
    private router: Router
  ) {
    this.form = this.fb.group({
      idDestino: [null, Validators.required],
      nombre: ['', Validators.required],
      fechaSalida: ['', Validators.required],
      fechaRegreso: ['', Validators.required],
      precioBase: [null, [Validators.required, Validators.min(0)]],
      descripcion: ['']
    });
  }

  ngOnInit(): void {
    this.destinoService.getDestinos().subscribe({
      next: (data) => { this.destinos = data; },
      error: (err) => { console.error('Error al cargar destinos', err); }
    });
  }

  guardar(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    this.paqueteService.createPaquete(this.form.value).subscribe({
      next: () => { this.router.navigate(['/paquetes']); },
      error: (err) => { console.error('Error al guardar paquete', err); }
    });
  }
}