using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }

    }
}
