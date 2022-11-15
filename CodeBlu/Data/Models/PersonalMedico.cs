using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CodeBlu.Data.Models
{
    [Index(nameof(DNI))]
    public class PersonalMedico
    {
        public int PersonalMedicoId { get; set; }

        //datos personales basicos del personal medico, siendo DNI una Unique key
        [Required, StringLength(255)]
        public string Nombre { get; set; }
        [Required, StringLength(255)]
        public string Apellido { get; set; }
        [Required, StringLength(255)]
        public string DNI { get; set; }

        //lista en la que se guardan todos los llamados que atendio este enfermero/a
        public List<Llamado> Llamados { get; set; } = new();

        //relacion con la zona que tiene asignada el enfermero/a
        public int ZonaId { get; set; }
        public Zona Zona { get; set; }

        //relacion con los pacientes que tiene asignado el enfermero/a
        public List<Paciente> Pacientes { get; set; } = new();
    }
}
