using Microsoft.EntityFrameworkCore;

namespace ApiEstudiantes.Models;

public class Conexiones : DbContext
{
    public Conexiones(DbContextOptions<Conexiones> options) : base(options)
    {
    }

    public DbSet<Estudiantes> Estudiantes { get; set; }
    public DbSet<Tipos_Sangre> Tipos_Sangre { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=db_estudiante;User=wc;Password=05052020;",
                new MySqlServerVersion(new Version(8, 0, 21)));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estudiantes>()
            .HasOne(e => e.Tipo_Sangre)
            .WithMany(ts => ts.Estudiantes)
            .HasForeignKey(e => e.id_tipo_sangre)
            .HasConstraintName("id_tipo_sangre_estudiantes_tipos_sangre");
    }

}