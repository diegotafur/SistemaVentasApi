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
    public class DeliveryController : ControllerBase
    {
        DeliveryService ds = new DeliveryService();

        [HttpGet]
        public IActionResult Get()
        {
            var result = ds.ObtenerDeliverys();
            if (result.Count < 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
