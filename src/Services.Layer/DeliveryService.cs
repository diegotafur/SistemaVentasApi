using Common.Layer;
using Domain.Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Services.Layer
{
    public class DeliveryService
    {

        public List<ListaDelivery> ObtenerDeliverys()
        {
            var deliverys = new List<ListaDelivery>();
            using (var context = new SqlConnection(Parameters.ConnectionString))
            {
                context.Open();
                var command = new SqlCommand("sp_ListarDeliveryDia", context);
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var delivery = new ListaDelivery
                    {
                        idVenta = Convert.ToInt32(reader["idVenta"]),
                        nombreCliente = reader["Cliente"].ToString(),
                        celular = reader["celular1"].ToString(),
                        anexo = reader["anexo"].ToString(),
                        piso = reader["piso"].ToString(),//Convert.ToDateTime(reader["fecha_nacimiento"]),
                        area = reader["area"].ToString(),
                        oficina = reader["oficina"].ToString(),
                        producto = reader["nombre"].ToString(),
                        importe = Convert.ToDouble(reader["importe"].ToString()),
                        fecha = Convert.ToDateTime(reader["fecha"]),
                        responsable = reader["Responsable"].ToString(),

                    };
                    deliverys.Add(delivery);
                }
            }
            return deliverys;
        }

    }
}
