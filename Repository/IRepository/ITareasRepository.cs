using Domain.Model;

namespace Repository.IRepository
{
    public interface ITareasRepository
    {
        Task<List<TareasModel>?> ConsultarTareas();
        Task<TareasModel>? ConsultarTareaId(int id);
        Task<bool> EliminarTareaId(int id);
        Task<bool> CrearTarea(TareasModel model);
        Task<TareasModel> ActualizarTarea(TareasModel model);

    }
}
