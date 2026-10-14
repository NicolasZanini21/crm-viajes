import { Routes } from '@angular/router';
import { PasajeroListComponent } from './pasajeros/pasajero-list/pasajero-list.component';
import { DestinoListComponent } from './destinos/destino-list/destino-list.component';
import { PaqueteListComponent } from './paquetes/paquete-list/paquete-list.component';
import { ReservaListComponent } from './reservas/reserva-list/reserva-list.component';
import { PasajeroFormComponent } from './pasajeros/pasajero-form/pasajero-form.component';
import { PasajeroFichaComponent } from './pasajeros/pasajero-ficha/pasajero-ficha.component';
import { DestinoFormComponent } from './destinos/destino-form/destino-form.component';
import { PaqueteFormComponent } from './paquetes/paquete-form/paquete-form.component';
import { PaqueteNuevoComponent } from './paquetes/paquete-nuevo/paquete-nuevo.component';
import { ReservaFormComponent } from './reservas/reserva-form/reserva-form.component';

export const routes: Routes = [
  { path: 'pasajeros', component: PasajeroListComponent },
  { path: 'pasajeros/nuevo', component: PasajeroFormComponent },
  { path: 'pasajeros/:id', component: PasajeroFichaComponent },
  { path: 'destinos', component: DestinoListComponent },
  {path: 'destinos/nuevo', component: DestinoFormComponent},
  { path: 'paquetes', component: PaqueteListComponent },
    { path: 'paquetes/nuevo', component: PaqueteNuevoComponent },
  { path: 'paquetes/nuevo/personalizado', component: PaqueteFormComponent },
  { path: 'reservas', component: ReservaListComponent },
  { path: 'reservas/nuevo', component: ReservaFormComponent },
  { path: '', redirectTo: 'pasajeros', pathMatch: 'full' }
];