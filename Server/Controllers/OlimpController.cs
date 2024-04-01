using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Server.DAL;
using ProyectoFinal.Shared.Models;

namespace ProyectoFinal.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OlimpController : ControllerBase
{
	private readonly OlimpiadasContext _context;

	public OlimpController(OlimpiadasContext context)
	{
		_context = context;
	}

	public bool Existe(int OlimpiadaId)
	{
		return (_context.TipoOlimpiada?.Any(p => p.TipoOlimpiadaId == OlimpiadaId)).GetValueOrDefault();
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<TipoOlimpiada>>> Obtener()
	{
		if (_context.TipoOlimpiada == null)
		{
			return NotFound();
		}
		else
		{
			return await _context.TipoOlimpiada.ToListAsync();
		}
	}

	[HttpGet("{TipoOlimpiadaId}")]
	public async Task<ActionResult<TipoOlimpiada>> ObtenerPeli(int TipoOlimpiadaId)
	{
		if (_context.TipoOlimpiada == null)
		{
			return NotFound();
		}

		var olimpiada = await _context.TipoOlimpiada
			.Where(l => l.TipoOlimpiadaId == TipoOlimpiadaId)
			.FirstOrDefaultAsync();

		if (olimpiada == null)
		{
			return NotFound();
		}
		return olimpiada;
	}

	[HttpPost]
	public async Task<ActionResult<TipoOlimpiada>> PostOlimp(TipoOlimpiada tipo)
	{
		if (!Existe(tipo.TipoOlimpiadaId))
		{
			_context.TipoOlimpiada.Add(tipo);
		}
		else
		{
			_context.TipoOlimpiada.Update(tipo);
		}

		await _context.SaveChangesAsync();
		return Ok(tipo);
	}

	[HttpDelete("{TipoOlimpiadaId}")]
	public async Task<IActionResult> Eliminar(int TipoOlimpiadaId)
	{
		if (_context.TipoOlimpiada == null)
		{
			return NotFound();
		}

		var olimpiada = await _context.TipoOlimpiada.FindAsync(TipoOlimpiadaId);

		if (olimpiada == null)
		{
			return NotFound();
		}

		_context.TipoOlimpiada.Remove(olimpiada);
		await _context.SaveChangesAsync();
		return NoContent();
	}
}