using Business.IService;
using Business.Service;
using Commun;
using Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace To_Do_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioS;

        public UsuarioController(IUsuarioService usuarioS)
        {
            this._usuarioS = usuarioS;
        }

        [HttpPost]
        [Route("CrearUsuario")]
        public async Task<Result> CrearUsuario([FromBody] UsuarioCrearDto usuarioCrear)
        {
            try
            {
                return await _usuarioS.CrearUsuario(usuarioCrear);
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
        [Route("ConsultarUsuarioEmail")]
        public async Task<Result> GetUsuariosemail(string correo)
        {
            Result oRespuesta = new();

            try
            {
                var vResult = await _usuarioS.ConsultarUsuarioEmail(correo);

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


        [HttpPost]
        [Route("ValidarLogin")]
        [AllowAnonymous]
        public async Task<Result> ValidarLogin([FromBody] IniciarSesionDto loginModel)
        {
            Result oRespuesta = new();

            try
            {
                var vRespuesta = await _usuarioS.ValidarLogin(loginModel);

                oRespuesta.Success = vRespuesta.Success;
                oRespuesta.Message = vRespuesta.Message;
                oRespuesta.Data = vRespuesta.Data;
            }
            catch (Exception ex)
            {
                
                oRespuesta.Success = false;
                oRespuesta.Message = ex.Message + " - Inner: " + ex.InnerException;
            }
            return oRespuesta;
        }
    }
}
