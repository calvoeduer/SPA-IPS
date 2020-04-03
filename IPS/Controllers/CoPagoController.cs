using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using IPS.Models.InputModels;
using IPS.Models.ViewModels;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static Logica.CoPagoService;

namespace IPS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoPagoController : Controller
    {
        private readonly CoPagoService coPagoService;


        public CoPagoController(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            coPagoService = new CoPagoService(connectionString);
        }



        // POST: api/Persona
        [HttpPost("[action]")]
        public CoPagoViewModel Insert([FromBody] CoPagoInputModel model)
        {
            CoPago copago = new CoPago()
            {
                Identificacion = model.Identificacion,
                Salario = model.Salario,
                ValorServicio = model.ValorServicio
            };
            CoPagoResponse response = coPagoService.Guardar(copago);
            if (response.Error)
            {
                return null;
            }
            return new CoPagoViewModel(response.CoPago);
        }

        [HttpGet("[action]")]
        public IEnumerable<CoPagoViewModel> Liquidaciones()
        {
            var liquidaciones = coPagoService.ConsultarTodos().Select(p => new CoPagoViewModel(p));
            return liquidaciones;
        }
    }
}