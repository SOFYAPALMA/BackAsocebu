namespace Domain.Model
{
    public class TareasModel
    {
       public int IdTarea { get; set; }
       public string Actividad { get; set; }
       public bool Estado { get; set; }
       public DateTime FechaApertura { get; set; }
       public DateTime FechaCierre{ get; set; }

    }
}
