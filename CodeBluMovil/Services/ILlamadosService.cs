using CodeBluCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBluMovil.Services
{
	public interface ILlamadosService
	{
        List<LlamadoDTO> Llamados { get; }
        Task<List<LlamadoDTO>> RefreshDataAsync();
    }
}
