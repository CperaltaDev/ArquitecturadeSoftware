using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Proyecto.Business.Interfaces;
using Proyecto.Data.Dto;


namespace Proyecto.Controllers
{
    [SwaggerTag("Controlador para consultar listar o agregar documentos")]

    /// <summary>
    /// Controlador productos  
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductoController : ControllerBase
    {
        private readonly IProducto _producto;

        public ProductoController(IProducto services) 
        {
            _producto = services;   
        }

        /// <summary>
        /// listado de productos Bancarios
        /// </summary>
        /// <response code="200">Productos: listado de los productos Bancarios <br/>
        /// Id: identificador unico <br/>
        /// Nombre producto: Nombre del producto Creado <br/>
        /// Codigo Producto: Codigo del producto creado <br/>
        /// Activo: Estado del producto <br/>
        /// 1 - Success, 2 - Error, 3 - NoRecords, 4 - ExpiredCode, 5 - UserNoExists, 6 - InvalidSession, 7 - InvalidPermissionRole <br/>
        /// message: Mensaje informativo
        /// </response>
        /// <response code="400">Error BadRequest</response>
        /// <response code="401">Acceso no autorizado</response>
        /// <response code="500">Oops! Error</response>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(ProductOut), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var output = await _producto.Selectall();
                return Ok(output);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }


    }
}
