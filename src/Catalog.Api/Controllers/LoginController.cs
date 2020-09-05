using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Layer;
using Microsoft.AspNetCore.Mvc;
using Services.Layer;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        LoginService ls = new LoginService();

        public LoginController()
        {

        }
        [HttpGet("{dni}")]
        public IActionResult Get(string dni)
        {
            var login = ls.ObtenerCliente(dni);

            if (login.Count <= 0)
            {
                login = ls.ObtenerEmpleado(dni);
                if (login.Count<=0)
                {
                    return NotFound();
                }
                else
                {
                    var d = ls.BuildToken(login);
                    return Ok(d);
                }
            }
            else
            {
                var d = ls.BuildToken(login);
                return Ok(d);
            }
           
        }
    }
}
