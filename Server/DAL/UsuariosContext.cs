using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Shared.Models;
using PruebadeLogin.Shared.Models;
using System.Data;

namespace ProyectoFinal.Server.DAL;

public class UsuariosContext : DbContext
{
	public UsuariosContext(DbContextOptions<UsuariosContext> options)
		:base(options) { }

	public DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Usuarios>().HasData(new List<Usuarios>()
            {
                new Usuarios(){
                    IdUsuario = 1,
                    Correo = "app@gmail.com",
                    Clave = "123"
                },
            });
    }
}