using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using ProyectoFinal.Server.DAL;
using ProyectoFinal.Shared.Models;
using SQLitePCL;


namespace ProyectoFinal.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OlimpiadasController : ControllerBase
	{
		private readonly OlimpiadasContext _context;

		public OlimpiadasController(OlimpiadasContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Olimpiadas>>> GetOlimpiada()
		{
			if (_context.Olimpiadas == null)
			{
				return NotFound();
			}
			return await _context.Olimpiadas.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Olimpiadas>> GetOlimpiada(int id)
		{
			if (_context.Olimpiadas == null)
			{
				return NotFound();
			}
			var olimpiada = _context.Olimpiadas
			  .Where(l => l.OlimpiadaId == id)
			  .Include(o => o.olimpiadaDetalle)
			  .AsNoTracking()
			  .SingleOrDefault(); ;

			if (olimpiada == null)
			{
				return NotFound();
			}

			return olimpiada;
		}

		[HttpPost]
		public async Task<ActionResult<Olimpiadas>> PostOlimpiadas(Olimpiadas olimpiada)
		{
			if (!Existe(olimpiada.OlimpiadaId))
				_context.Olimpiadas.Add(olimpiada);
			else
				_context.Olimpiadas.Update(olimpiada);

			await _context.SaveChangesAsync();
			return Ok(olimpiada);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteOlimpiadas(int id)
		{
			if (_context.Olimpiadas == null)
			{
				return NotFound();
			}

			var olimpiada = await _context.Olimpiadas.FindAsync(id);

			if (olimpiada == null)
			{
				return NotFound();
			}

			_context.Olimpiadas.Remove(olimpiada);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool Existe(int id)
		{
			return (_context.Olimpiadas?.Any(l => l.OlimpiadaId == id)).GetValueOrDefault();
		}
	}
}
