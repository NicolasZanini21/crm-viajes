import { Routes } from '@angular/router';
import { PasajeroListComponent } from './pasajeros/pasajero-list/pasajero-list.component';
import { DestinoListComponent } from './destinos/destino-list/destino-list.component';
import { PaqueteListComponent } from './paquetes/paquete-list/paquete-list.component';
import { ReservaListComponent } from './reservas/reserva-list/reserva-list.component';
import { PasajeroFormComponent } from './pasajeros/pasajero-form/pasajero-form.component';
import { PasajeroFichaComponent } from './pasajeros/pasajero-ficha/pasajero-ficha.component';

export const routes: Routes = [
  { path: 'pasajeros', component: PasajeroListComponent },
  { path: 'pasajeros/nuevo', component: PasajeroFormComponent },
  { path: 'pasajeros/:id', component: PasajeroFichaComponent },
  { path: 'destinos', component: DestinoListComponent },
  { path: 'paquetes', component: PaqueteListComponent },
  { path: 'reservas', component: ReservaListComponent },
  { path: '', redirectTo: 'pasajeros', pathMatch: 'full' }
];