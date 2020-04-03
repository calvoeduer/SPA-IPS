using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Datos
{
   public class CoPagoRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<CoPago> _liquidaciones = new List<CoPago>();

        public CoPagoRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public bool Guardar(CoPago coPago)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into LiquidacionesTable (Identificacion,Salario,ValorServicio,Tarifa,Valor) 
                                        values (@Identificacion,@Salario,@ValorServicio,@Tarifa,@Valor)";
                command.Parameters.AddWithValue("@Identificacion", coPago.Identificacion);
                command.Parameters.AddWithValue("@Salario", coPago.Salario);
                command.Parameters.AddWithValue("@ValorServicio", coPago.ValorServicio);
                command.Parameters.AddWithValue("@Tarifa", coPago.Tarifa);
                command.Parameters.AddWithValue("@Valor", coPago.Valor);
                int filas = command.ExecuteNonQuery();
                if (filas > 0)
                    return true;
                else return false;
            }
        }

        


        public List<CoPago> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<CoPago> coPagos = new List<CoPago>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from LiquidacionesTable ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        CoPago coPago = DataReaderMapToPerson(dataReader);
                        coPagos.Add(coPago);
                    }
                }
            }
            return coPagos;
        }

        private CoPago DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            CoPago coPago = new CoPago();
            coPago.Identificacion = (string)dataReader["Identificacion"];
            coPago.Salario = (decimal)dataReader["Salario"];
            coPago.ValorServicio = (decimal)dataReader["ValorServicio"];
            return coPago;
        }




    }
    
}
