using CodeBluCore.Enums;
using System.ComponentModel.DataAnnotations;

namespace CodeBluCore
{
    public class UserDTO
    {
        [Required, StringLength(255)]
        public string Usuario { get; set; }
        [Required, StringLength(255)]
        public string Contrasena { get; set; }
        public TipoRol Rol { get; set; }
    }
}
