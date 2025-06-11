using Commun;
using Dtos;

namespace Business.IService
{
    public interface IUsuarioService
    {
        Task<Result> CrearUsuario(UsuarioCrearDto Crear);
        Task<Result> ConsultarUsuarioEmail(string correo);
        Task<Result> ValidarLogin(IniciarSesionDto validar);

    }
}
