import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'manufacturer',
    loadComponent: () => import('./manufacturer/manufacturer.component').then(m => m.ManufacturerComponent)
  },
  {
    path: 'vehicle-models',
    loadComponent: () => import('./vehicle-models/vehicle-models.component').then(m => m.VehicleModelsComponent)
  },
  {
    path: '',
    redirectTo: 'manufacturer',
    pathMatch: 'full',
  },
  {
    path: '**',
    redirectTo: 'manufacturer',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
