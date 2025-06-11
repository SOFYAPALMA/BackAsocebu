using Domain.Model;

namespace Repository.IRepository
{
    public interface IUsuarioRepository
    {
        Task<bool> CrearUsuario(UsuarioModel model);
    }
}
