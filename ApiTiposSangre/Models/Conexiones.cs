using Microsoft.EntityFrameworkCore;

namespace ApiTiposSangre.Models;

public class Conexiones : DbContext
{
    public Conexiones(DbContextOptions<Conexiones> options)
        : base(options)
    {
    }

    public DbSet<tipos_sangre> tipos_sangre { get; set; } = null!;
}