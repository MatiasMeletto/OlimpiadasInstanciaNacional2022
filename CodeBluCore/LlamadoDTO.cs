using System;
using System.Collections.Generic;
using System.Linq;
using CodeBluCore.Enums;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CodeBluCore
{
	public class LlamadoDTO
	{
        [Required]
        public TipoLlamado TipoLlamado { get; set; }
        [Required]
        public TipoOrigenLlamado OrigenLlamado { get; set; }
        [Required]
        public bool Atendido { get; set; }
        [Required]
        public DateTime FechaHora { get; set; }
        [Required]
        public DateTime HoraAtendido { get; set; }
        [Required]
        public string Zona { get; set; }
        [Required]
        public string Paciente { get; set; }
        [Required]
        public string Personal { get; set; }
    }
}
