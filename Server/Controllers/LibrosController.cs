using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using ProyectoFinal.Server.DAL;
using ProyectoFinal.Shared.Models;
using SQLitePCL;

namespace ProyectoFinal.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibrosController : ControllerBase
{
	private readonly LibrosContext _context;

	public LibrosController(LibrosContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Libros>>> GetLibros()
	{
		if (_context.Libros == null)
		{
			return NotFound();
		}
		return await _context.Libros.ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Libros>> GetLibros(int id)
	{
		if (_context.Libros == null)
		{
			return NotFound();
		}
		var libro = _context.Libros
		  .Where(l => l.LibroId == id)
		  .Include(o => o.libroDetalle)
		  .AsNoTracking()
		  .SingleOrDefault(); ;

		if (libro == null)
		{
			return NotFound();
		}

		return libro;
	}

    [HttpPost]
    public async Task<ActionResult<Libros>> PostLibros(Libros libro)
    {
        if (!Existe(libro.LibroId))
            _context.Libros.Add(libro);
        else
            _context.Libros.Update(libro);

        await _context.SaveChangesAsync();
        return Ok(libro);
    }

    [HttpDelete("{id}")]
	public async Task<ActionResult> DeleteLibros(int id)
	{
		if (_context.Libros == null)
		{
			return NotFound();
		}

		var libro = await _context.Libros.FindAsync(id);

		if (libro == null)
		{
			return NotFound();
		}

		_context.Libros.Remove(libro);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	private bool Existe(int id)
	{
		return (_context.Libros?.Any(l => l.LibroId == id)).GetValueOrDefault();
	}
}