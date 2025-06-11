using Business.IService;
using Business.Mapp;
using Commun;
using Domain.Model;
using Dtos;
using Repository.IRepository;

namespace Business.Service
{
    public class TareasService : ITareasService
    {
        private readonly ITareasRepository _tareasR;
        public TareasService(ITareasRepository tareasR) 
        {
            _tareasR = tareasR;
        }


        public async Task<Result> ActualizarTarea(TareasDto actualizar)
        {
            TareasModel model = Mapper.GetMapper(actualizar);
                Result oRespuesta = new();

                var rs = await _tareasR.ActualizarTarea(model);

                Result result = new Result
                {
                    Success = false,
                    Message = "tarea actualizada con exito"
                };
                result.Success = true;
                result.Data = rs;

                return result;
            
        }

        public async Task<Result> ConsultarTareaId(int id)
        {
            TareasModel? tareas = await _tareasR.ConsultarTareaId(id);


            if (tareas != null)
            {
                TareasDto dto = Mapper.GetMapper(tareas);

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
                    Message = "Tarea no encontrada"
                };
                return result;
            }
        }

        public async Task<Result> ConsultarTareas()
        {
            {
                List<TareasModel>? tareas = await _tareasR.ConsultarTareas();
                List<TareasDto> dto = Mapper.GetMapper(tareas);
                Result result = new Result();
                result.Success = true;
                result.Data = dto;
                return result;

            }
        }

        public async Task<Result> CrearTarea(TareasCrearDto crear)
        {
            TareasModel model = Mapper.GetMapper(crear);
            var rs = await _tareasR.CrearTarea(model);

            Result result = new Result();
            result.Success = rs;
            return result;
        }

        public async Task<Result> EliminarTareaId(int id)
        {
            var rs = await _tareasR.EliminarTareaId(id);
            Result result = new Result
            {
                Success = false,
                Message = "Tarea eliminado con exito"
            };
            result.Success = true;
            result.Data = rs;

            return result;
        }
    }
}
