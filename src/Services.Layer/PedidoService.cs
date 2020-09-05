using Common.Layer;
using Domain.Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Services.Layer
{
    public class PedidoService
    {
        public List<Pedido> ObtenerPedidosPorVendedor(int idvendedor)
        {
            var pedidos = new List<Pedido>();
            using (var context = new SqlConnection(Parameters.ConnectionString))
            {
                context.Open();
                var command = new SqlCommand("sp_ListaPedidosDiaActualPorVendedor", context);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = idvendedor;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var pedido = new Pedido
                    {
                        IdVenta = Convert.ToInt32(reader["idVenta"]),
                        NombreCliente = reader["Cliente"].ToString(),

                       
                        Celular = reader["celular1"].ToString(), //reader["celular1"].ToString(),

                        Anexo = reader["anexo"].ToString(),
                        Piso = reader["piso"].ToString(),
                        Area = reader["area"].ToString(),
                        Oficina = reader["oficina"].ToString(),
                        NombreProducto = reader["nombre"].ToString(),
                        Cantidad = Convert.ToInt32(reader["Cantidad"].ToString()),
                        PrecioVenta = Convert.ToDouble(reader["precioVenta"].ToString()),
                        Importe = Convert.ToDouble(reader["importe"].ToString()),
                        Fecha = Convert.ToDateTime(reader["fecha"].ToString()),
                        NombreEmpleado = reader["Responsable"].ToString(),
                    };
                    pedidos.Add(pedido);
                }
            }
            return pedidos;
        }
    }
}
