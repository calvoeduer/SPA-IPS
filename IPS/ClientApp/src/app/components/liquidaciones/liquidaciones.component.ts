import { Component, OnInit } from '@angular/core';
import { CopagoRegistroComponent } from '../copago-registro/copago-registro.component';
import { Copago } from 'src/app/models/copago';
import { CopagoService } from 'src/app/services/copago.service';

@Component({
  selector: 'app-liquidaciones',
  templateUrl: './liquidaciones.component.html',
  styleUrls: ['./liquidaciones.component.css']
})
export class LiquidacionesComponent implements OnInit {

  liquidaciones: Copago[];

  constructor(private copagoService: CopagoService) { }
  searchText = '';

  ngOnInit(): void {
    this.copagoService.get().subscribe(liquidaciones => this.liquidaciones = liquidaciones);
  }

}
