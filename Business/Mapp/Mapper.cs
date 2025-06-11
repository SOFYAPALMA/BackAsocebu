using Domain.Model;
using Dtos;

namespace Business.Mapp
{
    public static class Mapper
    {
        public static List<UsuarioDto> GetMapper(List<UsuarioModel> ListaUsuarios)
        {
            var result = new List<UsuarioDto>();
            foreach (var model in ListaUsuarios)
            {
                result.Add(GetMapper(model));
            }
            return result;
        }
        public static UsuarioModel GetMapper(UsuarioDto usuario)
        {
            var result = new UsuarioModel()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Clave = usuario.Clave
            };
            return result;
        }
        public static UsuarioDto GetMapper(UsuarioModel usuario)
        {
            var result = new UsuarioDto()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Clave = usuario.Clave
            };
            return result;
        }
        public static UsuarioModel GetMapper(IniciarSesionDto sesion)
        {
            var result = new UsuarioModel()
            {
                Correo = sesion.Correo,
                Clave = sesion.Clave
            };

            return result;
        }


        public static List<TareasDto> GetMapper(List<TareasModel> ListaTareas)
        {
            var result = new List<TareasDto>();
            foreach (var model in ListaTareas)
            {
                result.Add(GetMapper(model));
            }
            return result;
        }
        public static TareasModel GetMapper(TareasDto tareas)
        {
            var result = new TareasModel()
            {
                IdTarea = tareas.IdTarea,
                Actividad = tareas.Actividad,
                Estado = tareas.Estado,
                FechaApertura = tareas.FechaApertura,
                FechaCierre = tareas.FechaCierre
            };
            return result;
        }
        public static TareasDto GetMapper(TareasModel tareas)
        {
            var result = new TareasDto()
            {
                IdTarea = tareas.IdTarea,
                Actividad = tareas.Actividad,
                Estado = tareas.Estado,
                FechaApertura = tareas.FechaApertura,
                FechaCierre = tareas.FechaCierre
            };
            return result;
        }
        public static TareasModel GetMapper(TareasCrearDto crear)
        {
            var result = new TareasModel()
            {
                Actividad = crear.Actividad,
                Estado = crear.Estado,
                FechaApertura = crear.FechaApertura,
                FechaCierre = crear.FechaCierre
            };
            return result;
        }


    }

}
