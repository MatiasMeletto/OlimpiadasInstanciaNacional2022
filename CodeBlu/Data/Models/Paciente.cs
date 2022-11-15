using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeBlu.Data.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }

        //datos personales del paciente
        [Required, StringLength(255)]
        public string Nombre { get; set; }
        [Required, StringLength(255)]
        public string Apellido { get; set; }
        [Required, StringLength(255)]
        public string DNI { get; set; }
        [Required, StringLength(255)]
        public string ContactoEmergencia{ get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public int Edad { get; set; }

        //datos medicos del paciente
        public bool Asma { get; set; }
        public bool TuvoVaricela { get; set; }
        [Required, StringLength(45)]
        public string TipoSangre { get; set; }
        [Required, StringLength(255)]
        public string ObraSocial { get; set; }
        public bool Alergia { get; set; }
        [StringLength(255)]
        public string? DetalleAlergia { get; set; }

        //relacion con la zona en la que se encuentra
        public int ZonaId { get; set; }
        public Zona Zona { get; set; }

        //relacion con el personal medico que tiene asignado
        public int PersonaMedicoId { get; set; }
        [ForeignKey("PersonalMedicoId")]
        public PersonalMedico Personal { get; set; }

        //relacion con los llamados que haga el paciente
        public List<Llamado> Llamados { get; set; } = new();
    }
}
