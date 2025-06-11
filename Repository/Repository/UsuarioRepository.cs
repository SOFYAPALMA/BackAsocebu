using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.IRepository;

namespace Repository.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {  _context = context; }

        public async Task<UsuarioModel>? ConsultarUsuarioEmail(string correo)
        {
            try
            {
                var usuarios = await _context.Usuario.FirstAsync(x => x.Correo == correo);
                return usuarios;
            }
            catch (Exception)
            {
                return new UsuarioModel();
                throw;
            }
        }

        public async Task<bool> CrearUsuario(UsuarioModel model)
        {
            try
            {
                await _context.Usuario.AddAsync(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

    }
}
