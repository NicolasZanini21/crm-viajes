import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DestinoService } from '../../services/destino.service';
import { ContinenteService } from '../../services/continente.service';
import { Continente } from '../../models/continente.model';

@Component({
  selector: 'app-destino-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './destino-form.component.html',
  styleUrl: './destino-form.component.css'
})
export class DestinoFormComponent implements OnInit {
  form: FormGroup;
  continentes: Continente[] = [];

  constructor(
    private fb: FormBuilder,
    private destinoService: DestinoService,
    private continenteService: ContinenteService,
    private router: Router
  ) {
    this.form = this.fb.group({
      destino: ['', Validators.required],
      pais: ['', Validators.required],
      idContinente: [null, Validators.required]
    });
  }

  ngOnInit(): void {
    this.continenteService.getContinentes().subscribe({
      next: (data) => { this.continentes = data; },
      error: (err) => { console.error('Error al cargar continentes', err); }
    });
  }

  guardar(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    this.destinoService.createDestino(this.form.value).subscribe({
      next: () => { this.router.navigate(['/destinos']); },
      error: (err) => { console.error('Error al guardar destino', err); }
    });
  }
}