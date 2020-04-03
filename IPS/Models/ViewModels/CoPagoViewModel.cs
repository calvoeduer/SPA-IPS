using Entity;
using IPS.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPS.Models.ViewModels
{
    public class CoPagoViewModel : CoPagoInputModel
    {
        public CoPagoViewModel(CoPago coPago)
        {
            Identificacion = coPago.Identificacion;
            Salario = coPago.Salario;
            ValorServicio = coPago.ValorServicio;
            Tarifa = coPago.Tarifa;
            Valor = coPago.Valor;
        }
        public float Tarifa { get; set; }
        public decimal Valor { get; set; }
    }
}
