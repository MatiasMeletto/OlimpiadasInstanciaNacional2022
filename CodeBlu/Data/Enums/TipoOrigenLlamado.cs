using System.ComponentModel.DataAnnotations;

namespace CodeBlu.Data.Enums
{
    public enum TipoOrigenLlamado
    {
        Otro,
        Cama,
        [Display(Name = "Baño")]
        Banio
        //pongo banio en lugar de baño para evitar usar ñ
    }
}
