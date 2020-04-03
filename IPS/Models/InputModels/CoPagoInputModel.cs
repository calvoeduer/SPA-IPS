using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPS.Models.InputModels
{
    public class CoPagoInputModel
    {
        public string Identificacion { get; set; }
        public decimal Salario { get; set; }
        public decimal ValorServicio { get; set; }
    }
}
