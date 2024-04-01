using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebadeLogin.Shared.Models
{
	public class Usuarios
	{
		[Key]
		public int IdUsuario { get; set; }

		[Required(ErrorMessage = "La credencial es incorrecta")]
		public string Correo { get; set; }

		[Required(ErrorMessage = "La credencial es incorrecta")]
		public string Clave { get; set; }
	}
}
