namespace Dtos
{
    public class TareasActualizarDto
    {
        public int IdTarea { get; set; }
        public string Actividad { get; set; }
        public bool Estado { get; set; }
        public DateTime? FechaCierre { get; set; }
    }
}
