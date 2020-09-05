using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Layer;
using Microsoft.AspNetCore.Mvc;
using Services.Layer;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeudaController : ControllerBase
    {
        DeudaService ds = new DeudaService();
        ResponseHelper res = new ResponseHelper();

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                int idEmpleado = Convert.ToInt32(id);
                var deudas = ds.ObtenerDeudasPorVendedor(idEmpleado);
                if (deudas.Count <= 0)
                {
                    deudas = ds.ObtenerDeudasPorCliente(idEmpleado);
                    if (deudas.Count <= 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return Ok(deudas);
                    }
                }
                else
                {
                    return Ok(deudas);
                }
            }
            catch (Exception ex)
            {
                res.Error = true;
                res.Message = ex.Message;
                return Ok(res);
            }
        }
    }
}
