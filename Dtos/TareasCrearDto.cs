using System.ComponentModel.DataAnnotations;

namespace Dtos
{
    public class TareasCrearDto
    {
        [Required(ErrorMessage = "La actividad es requerida")]
        public string Actividad { get; set; }       
        public DateTime? FechaCierre { get; set; }
    }
}
