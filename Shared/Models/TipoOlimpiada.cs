using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Shared.Models;

public class TipoOlimpiada
{
	[Key]

	public int TipoOlimpiadaId { get; set; }

	[Required(ErrorMessage = "La  categoria es requerido")]
	public string? Categoria { get; set; }

	public int Disponible { get; set; }

	[Required(ErrorMessage = "El el campo Participantes no puede estar vacío")]
	public string? Participantes { get; set; }
}