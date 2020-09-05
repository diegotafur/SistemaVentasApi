using Common.Layer;
using Domain.Layer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Layer
{
    public class LoginService
    {
        string keytoken = "HGTSRAJUIROLPIUSJSHBVSRTEHSKJAJSHJAQWBGRDZXSYDPOKLDISSWASNDHSYT";
        public List<Login> ObtenerCliente(string dni)
        {
            var persona = new List<Login>();
            using (var context = new SqlConnection(Parameters.ConnectionString))
            {
                context.Open();
                var command = new SqlCommand("sp_BuscarClienteDniApiLogin", context);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@textobuscar", SqlDbType.VarChar).Value = dni;
                //command.Parameters.AddWithValue("@textobuscar", dni);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var login = new Login
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nombre = reader["nombres"].ToString(),
                        Apellidos = reader["apellidos"].ToString(),

                    };
                    persona.Add(login);
                }
            }
            return persona;
        }
        public List<Login> ObtenerEmpleado(string dni)
        {
            var persona = new List<Login>();
            using (var context = new SqlConnection(Parameters.ConnectionString))
            {
                context.Open();
                var command = new SqlCommand("sp_BuscarEmpleadoDniApi", context);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@textobuscar", SqlDbType.VarChar).Value = dni;
                //command.Parameters.AddWithValue("@textobuscar", dni);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var login = new Login
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nombre = reader["nombres"].ToString(),
                        Apellidos = reader["apellidos"].ToString(),

                    };
                    persona.Add(login);
                }
            }
            return persona;
        }

        public Login BuildToken(List<Login> login)
        {

            Login lg = new Login();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName,login[0].Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,login[0].Nombre),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keytoken));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "www.aylluconsorcio.com",
                audience: "www.aylluconsorcio.com",
                claims: claims,
                expires: expiration,
                signingCredentials: credenciales);

            var tok = new JwtSecurityTokenHandler().WriteToken(token);
            var expi = expiration;
            lg.Id = login[0].Id;
            lg.Nombre = login[0].Nombre;
            lg.Apellidos = login[0].Apellidos;
            lg.token = tok;
            lg.expiracion = expi;

            return lg;
           
        }
    }
}
