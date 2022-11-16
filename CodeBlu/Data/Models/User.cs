using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CodeBlu.Data.Models
{
    [Index(nameof(DNI))]
    public class User
    {
        public int UserId { get; set; }

        [Required, StringLength(255)]
        public string Usuario { get; set; }
        [Required, StringLength(255)]
        public string Contrasena { get; set; } // esta contraseña deberia estar hasheada para mas seguridad, no esta hecho ya que es solo una demo de como podria ser
        [Required, StringLength(255)]
        public string DNI { get; set; } //se usa el DNI como unique key para que no pueda haber 2 dni iguales en 2 cuentas distintas y ademas se puede usar como vinculo al personal
    }
}
