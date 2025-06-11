using Domain.Model;
using Repository.Data;
using Repository.IRepository;

namespace Repository.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {  _context = context; }
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
