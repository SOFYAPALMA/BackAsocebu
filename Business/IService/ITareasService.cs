using Commun;
using Dtos;

namespace Business.IService
{
    public interface ITareasService
    {
        Task<Result> CrearTarea(TareasCrearDto crear);
        Task<Result> ActualizarTarea(TareasActualizarDto actualizar);
        Task<Result> ConsultarTareas();
        Task<Result> ConsultarTareaId(int id);
        Task<Result> EliminarTareaId(int id);



    }

}