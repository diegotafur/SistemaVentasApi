using Common.Layer;
using Domain.Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Services.Layer
{
    public class ClienteService
    {

        public  List<Cliente> ObtenerClientes()
        {
            var clientes = new List<Cliente>();
            using(var context = new SqlConnection(Parameters.ConnectionString))
            {
                context.Open();
                var command = new SqlCommand("sp_listar_cliente", context);
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var cliente = new Cliente
                    {
                        idCliente = Convert.ToInt32(reader["idCliente"]),
                        nombre = reader["nombre"].ToString(),
                        apellido = reader["apellido"].ToString(),
                        sexo = reader["sexo"].ToString(),
                        fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]),
                        tipo_documento = reader["tipo_documento"].ToString(),
                        numero_documento = reader["numero_documento"].ToString(),
                        direccion = reader["direccion"].ToString(),
                        celular1 = reader["celular1"].ToString(),
                        celular2 = reader["celular2"].ToString(),
                        email = reader["email"].ToString(),
                        facebook = reader["facebook"].ToString(),
                        oficina = reader["oficina"].ToString(),
                        piso = reader["piso"].ToString(),
                        anexo = reader["anexo"].ToString(),
                        area = reader["area"].ToString(),
                        estado = Convert.ToInt32(reader["estado"]),
                    };
                    clientes.Add(cliente);
                }
            }
            return clientes;
        }

        public List<Cliente> ObtenerClientes(string dni)
        {
            var clientes = new List<Cliente>();
            using (var context = new SqlConnection(Parameters.ConnectionString))
            {
                context.Open();
                var command = new SqlCommand("sp_buscar_cliente_numero_documento", context);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@textobuscar", SqlDbType.VarChar).Value = dni;
                //command.Parameters.AddWithValue("@textobuscar", dni);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var cliente = new Cliente
                    {
                        idCliente = Convert.ToInt32(reader["idCliente"]),
                        nombre = reader["nombre"].ToString(),
                        apellido = reader["apellido"].ToString(),
                        sexo = reader["sexo"].ToString(),
                        fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]),
                        tipo_documento = reader["tipo_documento"].ToString(),
                        numero_documento = reader["numero_documento"].ToString(),
                        direccion = reader["direccion"].ToString(),
                        celular1 = reader["celular1"].ToString(),
                        celular2 = reader["celular2"].ToString(),
                        email = reader["email"].ToString(),
                        facebook = reader["facebook"].ToString(),
                        oficina = reader["oficina"].ToString(),
                        piso = reader["piso"].ToString(),
                        anexo = reader["anexo"].ToString(),
                        area = reader["area"].ToString(),
                        estado = Convert.ToInt32(reader["estado"]),
                    };
                    clientes.Add(cliente);
                }
            }
            return clientes;
        }

        public List<Deuda> ObtenerDeudaCliente(int idcliente)
        {
            var deudas = new List<Deuda>();
            using (var context = new SqlConnection(Parameters.ConnectionString))
            {
                context.Open();
                var command = new SqlCommand("sp_BuscarDeudaClienteApi", context);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@idcliente", SqlDbType.Int).Value = idcliente;
                //command.Parameters.AddWithValue("@textobuscar", dni);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var deuda = new Deuda
                    {
                        nombreProducto = reader["nombreProducto"].ToString(),
                        //idFiado = Convert.ToInt32(reader["idFiado"]),
                        //idCliente = Convert.ToInt32(reader["idCliente"]),
                        //idVenta = Convert.ToInt32(reader["idVenta"]),
                        //idProducto = Convert.ToInt32(reader["idProducto"]),
                        cantidad = Convert.ToInt32(reader["cantidad"]),
                        precio = Convert.ToDouble(reader["precio"]),
                        //estado = Convert.ToInt32(reader["estado"]),
                        //adelanto = Convert.ToDouble(reader["adelanto"]),
                        //resta = Convert.ToDouble(reader["resta"]),
                        importe = Convert.ToDouble(reader["importe"]),
                        //fechaPago = Convert.ToDateTime(reader["fechaPago"]),
                    };
                    deudas.Add(deuda);
                }
            }
            return deudas;
        }




    }
}
