import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { Destino } from '../../models/destino.model';
import { Continente } from '../../models/continente.model';
import { DestinoService } from '../../services/destino.service';
import { ContinenteService } from '../../services/continente.service';

@Component({
  selector: 'app-destino-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './destino-list.component.html',
  styleUrl: './destino-list.component.css'
})
export class DestinoListComponent implements OnInit {
  destinos: Destino[] = [];
  continentes: Continente[] = [];

  constructor(
    private destinoService: DestinoService,
    private continenteService: ContinenteService
  ) { }

  ngOnInit(): void {
    this.destinoService.getDestinos().subscribe({
      next: (data) => { this.destinos = data; },
      error: (err) => { console.error('Error al cargar destinos', err); }
    });

    this.continenteService.getContinentes().subscribe({
      next: (data) => { this.continentes = data; },
      error: (err) => { console.error('Error al cargar continentes', err); }
    });
  }

  nombreContinente(idContinente: number): string {
    const continente = this.continentes.find(c => c.idContinente === idContinente);
    return continente ? continente.nombreContinente : '';
  }
}