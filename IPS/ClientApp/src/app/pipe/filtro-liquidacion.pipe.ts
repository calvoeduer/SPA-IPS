import { Pipe, PipeTransform } from '@angular/core';
import { Copago } from '../models/copago';

@Pipe({
  name: 'filtroLiquidacion'
})
export class FiltroLiquidacionPipe implements PipeTransform {

  transform(copago : Copago[], searchText: string): any {
    if (searchText == null) return copago;
    return copago.filter(c => c.identificacion.toLowerCase().indexOf(searchText.toLowerCase()) !== -1 )
  }

}
