using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Proyecto.Business.Interfaces;
using Proyecto.Data.Common;
using Proyecto.Data.Dto;
using Proyecto.Model.Interfaces;

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipodocumento _tipodocumento;

        public TipoDocumentoController(ITipodocumento services)
        {
            _tipodocumento = services;
        }

        /// <summary>
        /// listado de tipo de documentos x producto
        /// </summary>
        /// <response code="200">Productos: listado de tipo de documentos x producto <br/>
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
        [ProducesResponseType(typeof(TipoDocumentOut), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var output = await _tipodocumento.Selectall();
                return Ok(output);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Actualizar Tipo Documento
        /// </summary>
        /// <response code="200">Actualizar Tipo Documento<br/>
        /// Id: identificador unico <br/>
        /// Codigo Producto: Codigo del producto creado <br/>
        /// 1 - Success, 2 - Error, 3 - NoRecords, 4 - ExpiredCode, 5 - UserNoExists, 6 - InvalidSession, 7 - InvalidPermissionRole <br/>
        /// message: Mensaje informativo
        /// </response>
        /// <response code="400">Error BadRequest</response>
        /// <response code="401">Acceso no autorizado</response>
        /// <response code="500">Oops! Error</response>
        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(typeof(BaseOut), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ActualizarTipoDocumento(UpdateTipoDocumentIn update)
        {
            try
            {
                var output = await _tipodocumento.UpdateItem(update);
                return Ok(output);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Agregar Documentos
        /// </summary>
        /// <response code="200">Productos: agregar documentos <br/>
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
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(DocumentoIn), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> AgregarDocumento(DocumentoIn Add)
        {
            try
            {
                var output = await _tipodocumento.AddItem(Add);
                if (output.result == Result.Error)
                { return Problem(output.message); }
                else
                { return Ok(output); }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
