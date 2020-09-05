using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Layer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Layer;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductoController : ControllerBase
    {
        ProductoService pro = new ProductoService();
        ResponseHelper res = new ResponseHelper();


        [HttpGet]
        public IActionResult Get()
       {
            try
            {
                var result = pro.ObtenerProductos();
                if (result.Count < 0)
                {
                    return NotFound();
                }
                return Ok(result);
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
