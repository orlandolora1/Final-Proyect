using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Shared.Models;
using System.Data;

namespace ProyectoFinal.Server.DAL;

public class LibrosContext : DbContext
{
	public LibrosContext(DbContextOptions<LibrosContext> options)
		:base(options) { }

    public DbSet<Login> Login { get; set; }
    public DbSet<Roles> Roles { get; set; }
	public DbSet<Libros> Libros { get; set; }
	public DbSet<TipoLibro> TipoLibro { get; set; }
	public DbSet<LibrosDetalle> Detalle { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<TipoLibro>().HasData(new List<TipoLibro>()
		{
			new TipoLibro(){TipoId=1, Categoria="Poesía", Autor="",Disponible = 0 },
			new TipoLibro(){TipoId=2, Categoria="Ficción", Autor="",Disponible = 0},
			new TipoLibro(){TipoId=3, Categoria="Autoayuda y desarrollo personal", Autor="",Disponible = 0 },
			new TipoLibro(){TipoId=4, Categoria="Política y sociedad", Autor = "", Disponible = 0 },
			new TipoLibro(){TipoId=5, Categoria="Religión y espiritualidad", Autor = "", Disponible = 0 },
			new TipoLibro(){TipoId=6, Categoria="Historietas y cómics", Autor = "", Disponible = 0 },
			new TipoLibro(){TipoId=7, Categoria="Viajes y aventuras", Autor = "", Disponible = 0 },
			new TipoLibro(){TipoId=8, Categoria="Infantil y juvenil", Autor = "", Disponible = 0 }
		});

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Login>().HasData(new List<Login>()
            {
                new Login(){
                    LoginId = 1,
                    NombreCompleto = "Orlando Lora",
                    NombreUsuario = "Admin",
                    Email = "Loraorlando3713@gmail.com",
                    Password = "admin123",
                    PasswordHash = PasswordHashHelper.GetHashedPassword("admin123", PasswordHashHelper.GenerateSalt()),
                    Rol = 1 },
            });

        modelBuilder.Entity<Roles>().HasData(new List<Roles>()
            {
                new Roles(){ RolId = 1, NombreRol = "Administrador" },
                new Roles(){ RolId = 2, NombreRol = "Profesor" },
                new Roles(){ RolId = 3, NombreRol = "Estudiante" },
            });
    }
}