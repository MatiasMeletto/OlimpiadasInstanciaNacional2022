using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeBlu.Data.Models
{
    public class Zona
    {
        public int ZonaId { get; set; }

        //nombre de la zona
        [Required, StringLength(255)]
        public string Nombre { get; set; }

        //relacion con el personal medico de esa zona
        public List<PersonalMedico> Personal { get; set; } = new ();

        //relacion con los pacientes de la zona 
        public List<Paciente> Pacientes { get; set; } = new ();

        //relacion con los llamados de la zona 
        public List<Llamado> Llamados { get; set; } = new();
    }
}
