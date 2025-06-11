using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class TareasModel
    {
        [Key]
        public int IdTarea { get; set; }
        public string Actividad { get; set; }
        public bool Estado { get; set; } = false; //actividad incompleta
        public DateTime FechaApertura { get; set; } = DateTime.Now;
        public DateTime? FechaCierre { get; set; } // Nullable

    }
}
