using Domain.Layer;
using Microsoft.AspNetCore.Mvc;
using Services.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        ClienteService cs = new ClienteService();
        public ClienteController()
        {

        }


        // cliente
        [HttpGet]
        public  IActionResult Get()
        {
            var result = cs.ObtenerClientes();
            if (result.Count < 0)
            {
                return NotFound();
            }
            return Ok(result);


        }

        [HttpGet("{dni}")]
        public IActionResult Get(string dni)
        {
            var cliente = cs.ObtenerClientes(dni);

            if (cliente.Count <= 0)
            {
                return NotFound();
            }
            else
            {
                int idcliente = cliente[0].idCliente;
                var deuda = cs.ObtenerDeudaCliente(idcliente);
                cliente[0].deudas = deuda;
            }
            return Ok(cliente);
        }

    }
}
