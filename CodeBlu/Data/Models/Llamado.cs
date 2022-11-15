using CodeBlu.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeBlu.Data.Models
{
    public class Llamado
    {
        public int LlamadoId { get; set; }

        //enum para indicar si es un llamado normal o una emergencia
        public TipoLlamado TipoLlamado { get; set; }

        //enum para saber cual es el origen del llamado, si cama o baño
        public TipoOrigenLlamado OrigenLlamado { get; set; }

        //bool que se marca si el pedido fue atendido por alguien del personal medico
        public bool Atendido { get; set; }

        //dos datetime para saber cuando se hizo el llamado, cuando se atendio y depues calcular el tiempo de respuesta
        public DateTime FechaHora { get; set; }
        public DateTime HoraAtendido { get; set; }

        //relacion con personal medico para saber cual fue el que atendio el llamado
        public int PersonalMedicoId { get; set; }
        [ForeignKey("PersonalMedicoId")]
        public PersonalMedico QuienAtendio { get; set; }

        //relacion con zona para saber desde que zona se hizo 
        public int ZonaId { get; set; }
        public Zona zona { get; set; }

        //relacion con paciente para saber que paciente lo hizo
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}
