import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Destino } from '../../models/destino.model';
import { DestinoService } from '../../services/destino.service';

@Component({
  selector: 'app-destino-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './destino-list.component.html',
  styleUrl: './destino-list.component.css'
})
export class DestinoListComponent implements OnInit {
  destinos: Destino[] = [];

  constructor(private destinoService: DestinoService) { }

  ngOnInit(): void {
    this.destinoService.getDestinos().subscribe({
      next: (data) => {
        this.destinos = data;
      },
      error: (err) => {
        console.error('Error al cargar destinos', err);
      }
    });
  }
}