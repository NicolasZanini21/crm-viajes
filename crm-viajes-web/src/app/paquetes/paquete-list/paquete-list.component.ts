import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Paquete } from '../../models/paquete.model';
import { PaqueteService } from '../../services/paquete.service';

@Component({
  selector: 'app-paquete-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './paquete-list.component.html',
  styleUrl: './paquete-list.component.css'
})
export class PaqueteListComponent implements OnInit {
  paquetes: Paquete[] = [];

  constructor(private paqueteService: PaqueteService) { }

  ngOnInit(): void {
    this.paqueteService.getPaquetes().subscribe({
      next: (data) => {
        this.paquetes = data;
      },
      error: (err) => {
        console.error('Error al cargar paquetes', err);
      }
    });
  }
}
