import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PasajeroService } from '../../services/pasajero.service';
import { PasajeroDto } from '../../models/pasajero.model';

@Component({
  selector: 'app-pasajero-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './pasajero-form.component.html',
  styleUrl: './pasajero-form.component.css'
})
export class PasajeroFormComponent {
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private pasajeroService: PasajeroService,
    private router: Router
  ) {
    this.form = this.fb.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      dni: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      telefono: ['']
    });
  }

  onSubmit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const dto: PasajeroDto = this.form.value;

    this.pasajeroService.createPasajero(dto).subscribe({
      next: () => {
        this.router.navigate(['/pasajeros']);
      },
      error: (err) => {
        console.error('Error al crear pasajero', err);
      }
    });
  }
}
