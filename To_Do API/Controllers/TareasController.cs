using Business.IService;
using Commun;
using Dtos;
using Microsoft.AspNetCore.Mvc;

namespace To_Do_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly ITareasService _tareasS;

        public TareasController(ITareasService tareasS)
        {
           this._tareasS = tareasS;
        }

        [HttpPost]
        [Route("CrearTarea")]

        public async Task<Result> CrearTarea([FromBody] TareasCrearDto tareasCrear)
        {
            try
            {
                return await _tareasS.CrearTarea(tareasCrear);
            }
            catch (Exception ex)
            {
                Result oRespuesta = new();
                oRespuesta.Success = false;
                oRespuesta.Message = ex.Message + " - Inner: " + ex.InnerException;

                return oRespuesta;
            }
        }

        [HttpGet]
        [Route("ConsultarTareas")]
        public async Task<Result> ConsultarTareas()
        {
            Result oRespuesta = new();

            try
            {
                var vResult = await _tareasS.ConsultarTareas();

                oRespuesta.Success = vResult.Success;
                oRespuesta.Message = vResult.Message;
                oRespuesta.Data = vResult.Data;
            }
            catch (Exception ex)
            {
                oRespuesta.Success = false;
                oRespuesta.Message = ex.Message + " - Inner: " + ex.InnerException;

            }
            return (oRespuesta);
        }

        [HttpGet]
        [Route("ConsultarTareaId")]
        public async Task<Result> ConsultarTareaId(int id)
        {
            Result oRespuesta = new();

            try
            {
                var vResult = await _tareasS.ConsultarTareaId(id);

                oRespuesta.Success = vResult.Success;
                oRespuesta.Message = vResult.Message;
                oRespuesta.Data = vResult.Data;
            }
            catch (Exception ex)
            {
                oRespuesta.Success = false;
                oRespuesta.Message = ex.Message + " - Inner: " + ex.InnerException;

            }
            return (oRespuesta);
        }

        [HttpPut]
        [Route("ActualizarTarea")]
        public async Task<IActionResult> ActualizarTarea([FromBody] TareasDto objModel)
        {
            Result oRespuesta = new();

            try
            {
                var vRespuesta = await _tareasS.ActualizarTarea(objModel);

                oRespuesta.Success = vRespuesta.Success;
                oRespuesta.Message = vRespuesta.Message;
                oRespuesta.Data = vRespuesta.Data;
            }
            catch (Exception ex)
            {

                oRespuesta.Success = false;
                oRespuesta.Message = ex.Message + " - Inner: " + ex.InnerException;
            }
            return Ok(oRespuesta);
        }

        [HttpDelete]
        [Route("EliminarTareaId")]
        public async Task<Result> EliminarTareaId(int id)
        {
            Result oRespuesta = new();
            try
            {
                var vRespuesta = await _tareasS.EliminarTareaId(id);

                oRespuesta.Success = vRespuesta.Success;
                oRespuesta.Message = vRespuesta.Message;
                oRespuesta.Data = vRespuesta.Data;
            }
            catch (Exception ex)
            {
                oRespuesta.Success = false;
                oRespuesta.Message = ex.Message + " - Inner: " + ex.InnerException;

            }
            return (oRespuesta);
        }


    }
}



