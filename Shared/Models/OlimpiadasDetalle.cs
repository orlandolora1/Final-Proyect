using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Shared.Models;

public class OlimpiadasDetalle
{
	[Key]

	public int DetalleOlimpiadaId { get; set; }

	public int OlimpiadaId { get; set; }

	public int TipoOlimpiadaId { get; set; }

	public int Disponible { get; set; }

	public string? Participantes { get; set; }
}