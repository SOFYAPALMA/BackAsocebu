using Business.IService;
using Business.Mapp;
using Commun;
using Domain.Model;
using Dtos;
using Repository.IRepository;

namespace Business.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioR;
        public UsuarioService(IUsuarioRepository usuarioR)
        {
            _usuarioR = usuarioR;
        }

        public async Task<Result> CrearUsuario(UsuarioCrearDto crear)
        {
            Result result = new Result();
            UsuarioModel usuario = Mapper.GetMapper(crear);

            UsuarioModel usuarioC = await _usuarioR.ConsultarUsuarioEmail(crear.Correo);

            if (usuarioC.Correo == null)
            {
                var rs = await _usuarioR.CrearUsuario(usuario);

                result.Success = rs;
            }
            else
            {
                result.Success = false;
                result.Message = "Ya existe el correo ";
            }

            return result;
        }

        public async Task<Result> ConsultarUsuarioEmail(string correo)
        {
            UsuarioModel? usuario = await _usuarioR.ConsultarUsuarioEmail(correo);


            if (usuario != null)
            {
                UsuarioDto dto = Mapper.GetMapper(usuario);

                Result result = new Result
                {
                    Success = true,
                    Data = dto
                };
                return result;

            }
            else
            {
                Result result = new Result
                {
                    Success = false,
                    Message = "Correo ya registrado"
                };
                return result;
            }
        }

        public async Task<Result> ValidarLogin(IniciarSesionDto validar)
        {
            {
                UsuarioModel usuar = Mapper.GetMapper(validar);
                var rs = await _usuarioR.CrearUsuario(usuar);

                Result result = new Result();
                result.Success = true;
                result.Data = rs;
                return result;
            }
        }
    }
}
