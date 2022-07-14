import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import { GovernsComponent } from 'src/Components/governs/governs.component';
import { CitiesComponent } from 'src/Components/cities/cities.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormCityComponent } from 'src/Components/form-city/form-city.component';

@NgModule({
  declarations: [
    AppComponent,
    GovernsComponent,
    CitiesComponent,
    FormCityComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
