using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Shared.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? NombreCompleto { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? NombreUsuario { get; set; }

        public string? Email { get; set; }

        [Required(ErrorMessage = "El campo password es obligatorio")]
        public string? Password { get; set; }

        public string? PasswordHash { get; set; }

        public string? Salt { get; set; }

        public int Rol { get; set; }

        [ForeignKey(("LoginId"))]
        public ICollection<LibrosDetalle> LibroLoginDetalle { get; set; } = new List<LibrosDetalle>();
    }
}