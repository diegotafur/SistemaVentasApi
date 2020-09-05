using Common.Layer;
using Domain.Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Services.Layer
{
    public class ProductoService
    {
        public List<Producto> ObtenerProductos()
        {
            var productos = new List<Producto>();
            using (var context = new SqlConnection(Parameters.ConnectionString))
            {
                context.Open();
                var command = new SqlCommand("sp_ListarProductosApi", context);
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var producto = new Producto
                    {
                        idProducto = Convert.ToInt32(reader["idProducto"]),
                        //codigo = reader["codigo"].ToString(),
                        nombre = reader["nombre"].ToString(),
                        descripcion = reader["descripcion"].ToString(),
                        //idCategoria = Convert.ToInt32(reader["idCategoria"].ToString()),
                        //idPresentacion = Convert.ToInt32(reader["idPresentacion"].ToString()),
                        ventaEstado = Convert.ToBoolean(reader["VentaEstado"].ToString()),
                        precioVenta = Convert.ToDouble(reader["precioVenta"].ToString()),
                        stock = Convert.ToInt32(reader["stock"].ToString()),
                        //caducaDia = Convert.ToBoolean(reader["caducaDia"].ToString()),
                        nombrecategoria = reader["categoria"].ToString(),
                    };
                    productos.Add(producto);
                }
            }
            return productos;
        }
    }
}
