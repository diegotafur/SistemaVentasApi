using Common.Layer;
using Domain.Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Services.Layer
{
    public class DeudaService
    {
        public List<Deuda> ObtenerDeudasPorVendedor(int idvendedor)
        {
            var deudas = new List<Deuda>();
            using (var context = new SqlConnection(Parameters.ConnectionString))
            {
                context.Open();
                var command = new SqlCommand("sp_ListarDeudaClientePorVendedor", context);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = idvendedor;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var deuda = new Deuda
                    {
                        idFiado = Convert.ToInt32(reader["idFiado"]),
                        idVenta = Convert.ToInt32(reader["idVenta"].ToString()),
                        idCliente = Convert.ToInt32(reader["idCliente"].ToString()),
                        idProducto = Convert.ToInt32(reader["idProducto"].ToString()),
                        idEmpleado = Convert.ToInt32(reader["idEmpleado"].ToString()),
                        NombreEmpleado = reader["Vendedor"].ToString(),
                        NombreCliente = reader["Cliente"].ToString(),
                        FechaFiado = Convert.ToDateTime(reader["fecha"].ToString()),
                        nombreProducto = reader["nombre"].ToString(),
                        cantidad = Convert.ToInt32(reader["cantidad"].ToString()),
                        precio = Convert.ToDouble(reader["precio"].ToString()),
                        importe = Convert.ToDouble(reader["Total"].ToString()),
                    };
                    deudas.Add(deuda);
                }
            }
            return deudas;
        }

        public List<Deuda> ObtenerDeudasPorCliente(int idvendedor)
        {
            var deudas = new List<Deuda>();
            using (var context = new SqlConnection(Parameters.ConnectionString))
            {
                context.Open();
                var command = new SqlCommand("sp_ListarDeudaClientePorCliente", context);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = idvendedor;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var deuda = new Deuda
                    {
                        idFiado = Convert.ToInt32(reader["idFiado"]),
                        idVenta = Convert.ToInt32(reader["idVenta"].ToString()),
                        idCliente = Convert.ToInt32(reader["idCliente"].ToString()),
                        idProducto = Convert.ToInt32(reader["idProducto"].ToString()),
                        idEmpleado = Convert.ToInt32(reader["idEmpleado"].ToString()),
                        NombreEmpleado = reader["Vendedor"].ToString(),
                        NombreCliente = reader["Cliente"].ToString(),
                        FechaFiado = Convert.ToDateTime(reader["fecha"].ToString()),
                        nombreProducto = reader["nombre"].ToString(),
                        cantidad = Convert.ToInt32(reader["cantidad"].ToString()),
                        precio = Convert.ToDouble(reader["precio"].ToString()),
                        importe = Convert.ToDouble(reader["Total"].ToString()),
                    };
                    deudas.Add(deuda);
                }
            }
            return deudas;
        }
    }
}
