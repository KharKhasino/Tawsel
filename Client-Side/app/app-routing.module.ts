import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CitiesComponent } from 'src/Components/cities/cities.component';
import { FormCityComponent } from 'src/Components/form-city/form-city.component';
import { GovernsComponent } from 'src/Components/governs/governs.component';

const routes: Routes = [
  { path: 'governs', component: GovernsComponent },
  { path: 'governs/:id', component: CitiesComponent },
  { path: 'governs/:id/Add', component: FormCityComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
