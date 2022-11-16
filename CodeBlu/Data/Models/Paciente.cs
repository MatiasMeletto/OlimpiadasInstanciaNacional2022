using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeBlu.Data.Models
{
    [Index(nameof(DNI))]
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
        public DateTime FechaNacimiento { get; set; } // habria que usar un DateOnly en lugar de DateTime, no me deja porque dice que no es un tipo primitivo soportado
        public int Edad { get; set; }

        //datos medicos del paciente
        public bool Asma { get; set; }
        public bool TuvoVaricela { get; set; } //estos son algunos ejemplos de antecedentes
        [Required, StringLength(45)]
        public string TipoSangre { get; set; }
        [Required, StringLength(255)]
        public string ObraSocial { get; set; }
        [Required, StringLength(255)]
        public string MedicoCabecera { get; set; } // medico de cabecera
        [Required, StringLength(255)]
        public string DiagnosticoIngreso { get; set; } //razon por la que fue ingresado en el hospital en primera instancia
        public bool Alergia { get; set; } // si tiene alergia o no, en caso de que tenga se aclara cual en el detalle
        [StringLength(255)]
        public string? DetalleAlergia { get; set; }
        [Required, StringLength(255)]
        public string PatologiaBase { get; set; } // si tiene alguna patologia previa condicinante como por ejemplo insuficiencia cardiaca
        public bool TomaMedicacion { get; set; } // si toma medicacion o no, en caso de ser afirmativo se aclara cual en el detalle
        public string? DetalleMedicacion { get; set; }


        //relacion con la zona en la que se encuentra
        public int ZonaId { get; set; }
        public Zona Zona { get; set; }

        //relacion con el personal medico que tiene asignado
        public int PersonalMedicoId { get; set; }
        [ForeignKey("PersonalMedicoId")]
        public PersonalMedico Personal { get; set; }

        //relacion con los llamados que haga el paciente
        public List<Llamado> Llamados { get; set; } = new();
    }
}
