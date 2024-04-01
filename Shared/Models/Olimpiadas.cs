using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Shared.Models;

public class Olimpiadas
{
    [Key]

    public int OlimpiadaId { get; set; }

    public byte[]? Imagen { get; set; }

    [Required(ErrorMessage = "El Titulo es un campo requerido")]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "El Email es un campo requerido")]
    public string? Email { get; set; }

    public DateTime Fecha { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "La Puntuacion es un campo requerido")]
    public int Puntuacion { get; set; }

    public string? Resena { get; set; }

    public string? Observacion { get; set; }

	public int TipoOlimpiadaId { get; set; }

	[ForeignKey("OlimpiadaId")]
	public ICollection<OlimpiadasDetalle> olimpiadaDetalle { get; set; } = new List<OlimpiadasDetalle>();
}