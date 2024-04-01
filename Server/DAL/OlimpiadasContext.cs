using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Shared.Models;

namespace ProyectoFinal.Server.DAL
{
    public class OlimpiadasContext : DbContext
    {
        public OlimpiadasContext(DbContextOptions<OlimpiadasContext> options)
            : base(options) { }

        public DbSet<Olimpiadas> Olimpiadas { get; set; }
		public DbSet<TipoOlimpiada> TipoOlimpiada { get; set; }
		public DbSet<OlimpiadasDetalle> OlimpiadaDetalle { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<TipoOlimpiada>().HasData(new List<TipoOlimpiada>()
		{
			new TipoOlimpiada(){TipoOlimpiadaId=1, Categoria="Matematica", Participantes="",Disponible = 0 },
			new TipoOlimpiada(){TipoOlimpiadaId=2, Categoria="Lengua Espanola", Participantes="",Disponible = 0},
			new TipoOlimpiada(){TipoOlimpiadaId=3, Categoria="Ciencias Naturales", Participantes="",Disponible = 0 },
			new TipoOlimpiada(){TipoOlimpiadaId=4, Categoria="Ciencias Sociales", Participantes = "", Disponible = 0 },
			new TipoOlimpiada(){TipoOlimpiadaId=5, Categoria="Politica y Sociedad ", Participantes = "", Disponible = 0 },
			new TipoOlimpiada(){TipoOlimpiadaId=6, Categoria="História", Participantes = "", Disponible = 0 },
			new TipoOlimpiada(){TipoOlimpiadaId=7, Categoria="Deletreo", Participantes = "", Disponible = 0 },
			new TipoOlimpiada(){TipoOlimpiadaId=8, Categoria="Escritura", Participantes = "", Disponible = 0 }
		});
		}
	}
}