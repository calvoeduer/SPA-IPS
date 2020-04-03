import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from './home/home.component';
import { CopagoRegistroComponent } from './components/copago-registro/copago-registro.component';
import { LiquidacionesComponent } from './components/liquidaciones/liquidaciones.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'registrar', component: CopagoRegistroComponent },
  { path: 'liquidaciones', component: LiquidacionesComponent }
];


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
