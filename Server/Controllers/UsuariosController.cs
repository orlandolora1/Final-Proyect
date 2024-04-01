using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Server.DAL;
using ProyectoFinal.Server.Migrations.Usuarios;
using ProyectoFinal.Shared.Models;
using Radzen;

namespace ProyectoFinal.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly UsuariosContext _context;

	public UsuariosController(UsuariosContext context)
	{
		_context = context;
	}

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] Sesion login)
    {
		var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == login.Correo);
		var dos = await _context.Usuarios.FirstOrDefaultAsync(u => u.Clave == login.Clave);
		LoginDTO sesionDTO = new LoginDTO();

		if(user != null && dos != null) 
		{
			if (login.Correo == user.Correo && login.Clave == dos.Clave)
			{
				sesionDTO.Nombre = "admin";
				sesionDTO.Correo = login.Correo;
				sesionDTO.Rol = "Administrador";
			}
			return StatusCode(StatusCodes.Status200OK, sesionDTO);			
		}
		return null;
    }
}