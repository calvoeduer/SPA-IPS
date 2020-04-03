using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using static Logica.CoPagoService;

namespace Logica
{
   public class CoPagoService
    {
        private readonly ConnectionManager _conexion;
        private readonly CoPagoRepository _repositorio;
        public CoPagoService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new CoPagoRepository(_conexion);
        }

        public CoPagoResponse Guardar(CoPago coPago)
        {
            try
            {
                _conexion.Open();
                _repositorio.Guardar(coPago);
                
                _conexion.Close();
                return new CoPagoResponse(coPago);
            }
            catch (Exception e)
            {
                return new CoPagoResponse($"Error de aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public List<CoPago> ConsultarTodos()
        {

            try
            {
               _conexion.Open();
                List<CoPago> coPagos = _repositorio.ConsultarTodos();
                _conexion.Close();
                return coPagos;
            }
            catch (Exception)
            {
                return null;
            }

           
        }


        public class CoPagoResponse
        {
            public CoPagoResponse(CoPago coPago)
            {
                Error = false;
                CoPago = coPago;
            }
            public CoPagoResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public CoPago CoPago { get; set; }
        }
    }
}
