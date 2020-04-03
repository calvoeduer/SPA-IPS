using System;

namespace Entity
{
    public class CoPago
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public decimal Salario       { get; set; }
        public decimal ValorServicio { get; set; }
        public float Tarifa
        {
            get
            {
                if (Salario > 2500000)
                    return 0.2f;
                else return 0.1f;
            }
        }
        public decimal Valor
        {
            get
            {
                return (decimal)Tarifa * ValorServicio;
            }
        }
    }
}
