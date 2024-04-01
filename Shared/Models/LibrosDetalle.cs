using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Shared.Models;

public class LibrosDetalle
{
	[Key]

	public int DetalleId { get; set; }

	public int LibroId { get; set; }

	public int TipoId { get; set; }

	public int Disponible { get; set; }

    public string? Autor { get; set; }
}