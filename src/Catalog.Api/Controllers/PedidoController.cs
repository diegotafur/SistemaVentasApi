using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Layer;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        PedidoService pes = new PedidoService();
        [HttpGet("{idempleado}")]
        public IActionResult Get(string id)
        {
            int idEmpleado = Convert.ToInt32(id);
            var pedidos = pes.ObtenerPedidosPorVendedor(idEmpleado);

            if (pedidos.Count <= 0)
            {
                return NotFound();
            }
            else
            {
                //int idcliente = cliente[0].idCliente;
                //var deuda = cs.ObtenerDeudaCliente(idcliente);
                ///cliente[0].deudas = deuda;
            }
            return Ok(pedidos);
        }
    }
}
