using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Server.DAL;
using ProyectoFinal.Shared.Models;

namespace ProyectoFinal.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TiposController : ControllerBase
{
	private readonly LibrosContext _context;

	public TiposController(LibrosContext context)
	{
		_context = context;
	}

	public bool Existe(int LibroId)
	{
		return (_context.TipoLibro?.Any(p => p.TipoId == LibroId)).GetValueOrDefault();
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<TipoLibro>>> Obtener()
	{
		if (_context.TipoLibro == null)
		{
			return NotFound();
		}
		else
		{
			return await _context.TipoLibro.ToListAsync();
		}
	}

	[HttpGet("{TipoId}")]
	public async Task<ActionResult<TipoLibro>> ObtenerTipos(int TipoId)
	{
		if (_context.TipoLibro == null)
		{
			return NotFound();
		}

		var libro = await _context.TipoLibro.FindAsync(TipoId);

		if (libro == null)
		{
			return NotFound();
		}
		return libro;
	}

	[HttpPost]
	public async Task<ActionResult<TipoLibro>> PostTipos(TipoLibro tipo)
	{
		if (!Existe(tipo.TipoId))
		{
			_context.TipoLibro.Add(tipo);
		}
		else
		{
			_context.TipoLibro.Update(tipo);
		}

		await _context.SaveChangesAsync();
		return Ok(tipo);
	}

	[HttpDelete("{TipoId}")]
	public async Task<IActionResult> Eliminar(int LibroId)
	{
		if (_context.TipoLibro == null)
		{
			return NotFound();
		}

		var libro = await _context.TipoLibro.FindAsync(LibroId);

		if (libro == null)
		{
			return NotFound();
		}

		_context.TipoLibro.Remove(libro);
		await _context.SaveChangesAsync();
		return NoContent();
	}
}

