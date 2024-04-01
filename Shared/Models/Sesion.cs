using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Shared.Models
{
    public class Sesion
    {
        [Required (ErrorMessage ="La credencial es incorrecta")]
        public string Correo { get; set; }

		[Required(ErrorMessage = "La credencial es incorrecta")]
		public string Clave { get; set; }
    }
}
