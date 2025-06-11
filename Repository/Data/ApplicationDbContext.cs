using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // configuracion para TareasModel
            modelBuilder.Entity<TareasModel>(entity =>
            {
                //configuracion de estado, False (Incompleto) 
                //entity.Property(e => e.Estado)
                //      .HasDefaultValue(false)  // En la BD se crea la actividad con DEFAULT FALSE
                //      .IsRequired();  //para evitar los nulos
                      

                // Opcional: Configuración para la fecha de apertura
                entity.Property(e => e.FechaApertura)
                      .HasDefaultValueSql("GETDATE()"); // Para SQL Server

                // FechaCierre puede ser NULL inicialmente
                entity.Property(e => e.FechaCierre)
                      .IsRequired(false);
            });
                       
           
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<TareasModel> Tareas { get; set; }
       

    }
}
