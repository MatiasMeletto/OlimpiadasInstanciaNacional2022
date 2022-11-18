using CodeBlu.Data;
using CodeBlu.Data.Models;
using CodeBluCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeBlu.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LlamadosController : ControllerBase
	{
        //Estes controller se usa para poder responder a la app movil con los llamados que hay en la base de datos

        //declaro un dbcontext
        private readonly CodeBluingDbContext _dbContext;
        public LlamadosController(CodeBluingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<LlamadosController>
        [HttpGet]
        public IEnumerable<LlamadoDTO> Get()
        {
            //traigo la lista de todos los llamados e inicializo una lista de LlamadoDTO
            List<Llamado> llamados = _dbContext.Llamados.Include(l => l.zona).Include(l => l.QuienAtendio).Include(l => l.Paciente).AsNoTracking().ToList();
            List<LlamadoDTO> llamadosDTO = new List<LlamadoDTO>();

            //por cada llamado creo un llamadoDTO y los devuelvo como valor
            foreach (Llamado llamado in llamados)
            {
                LlamadoDTO commentDTO = new LlamadoDTO()
                {
                    Atendido = llamado.Atendido,
                    HoraAtendido = llamado.HoraAtendido,
                    FechaHora = llamado.FechaHora,
                    OrigenLlamado = (CodeBluCore.Enums.TipoOrigenLlamado)llamado.OrigenLlamado,
                    Paciente = $"{llamado.Paciente.Nombre} {llamado.Paciente.Apellido}",
                    Personal = $"{llamado.QuienAtendio.Nombre} {llamado.QuienAtendio.Apellido}",
                    TipoLlamado = (CodeBluCore.Enums.TipoLlamado)llamado.TipoLlamado,
                    Zona = llamado.zona.Nombre
                };
                llamadosDTO.Add(commentDTO);
            }

            return llamadosDTO;
        }

        // GET api/<LlamadosController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //	return "value";
        //}

        // POST api/<LlamadosController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<LlamadosController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<LlamadosController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
