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
    public class MenuController : Controller
    {
        MenuService pro = new MenuService();
        [HttpGet]
        public IActionResult Get()
        {
            var result = pro.ObtenerMenus();
            if (result.Count < 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
