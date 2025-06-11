using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.IRepository;

namespace Repository.Repository
{
    public class TareasRepository : ITareasRepository
    {
        public readonly ApplicationDbContext _context;

        public TareasRepository(ApplicationDbContext context)
        {  _context = context; }

        public async Task<TareasModel> ActualizarTarea(TareasModel model)
        {
            try
            {
                var tareaExistente = await _context.Tareas.FindAsync(model.IdTarea);

                if (tareaExistente == null)
                {
                    return new TareasModel();
                }
                tareaExistente.IdTarea = model.IdTarea;
                tareaExistente.Actividad = model.Actividad;
                tareaExistente.Estado = model.Estado;
                tareaExistente.FechaApertura = model.FechaApertura;
                tareaExistente.FechaCierre = model.FechaCierre;

                await _context.SaveChangesAsync();

                return tareaExistente;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new TareasModel();
            }
        }

        public async Task<TareasModel>? ConsultarTareaId(int id)
        {
            try
            {
                var tarea = await _context.Tareas.Where(p => p.IdTarea == id).FirstOrDefaultAsync();

                return tarea;
            }
            catch (Exception ex)
            {
                return new TareasModel();
                throw;
            }
        }

        public async Task<List<TareasModel>?> ConsultarTareas()
        {
            try
            {
                var listResult = await _context.Tareas.AsQueryable().ToListAsync();
                return listResult;
            }
            catch (Exception ex)
            {
                return new List<TareasModel>();
                throw;
            }
        }

        public async Task<bool> CrearTarea(TareasModel model)
        {
            try
            {
                await _context.Tareas.AddAsync(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> EliminarTareaId(int id)
        {
            try
            {
                var lstResult = await _context.Tareas.FirstAsync(x => x.IdTarea == id);
                _context.Tareas.Remove(lstResult);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
