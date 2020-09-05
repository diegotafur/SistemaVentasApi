using Common.Layer;
using Domain.Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Services.Layer
{
    public class MenuService
    {
        public List<Menu> ObtenerMenus()
        {
            var menus = new List<Menu>();
            using (var context = new SqlConnection(Parameters.ConnectionString))
            {
                context.Open();
                var command = new SqlCommand("sp_ListarMenuFechaActual", context);
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var menu = new Menu
                    {
                        IdMenuDia = Convert.ToInt32(reader["idmenudia"]),
                        FechaServir = Convert.ToDateTime(reader["fechaservir"].ToString()),
                        Categoria = reader["categoria"].ToString(),
                        Nombre = reader["nombre"].ToString(),
                        Cantidad = Convert.ToInt32(reader["cantidad"].ToString()),
                        

                    };
                    menus.Add(menu);
                }
            }
            return menus;
        }
    }
}
