using CodeBlu.Data;
using CodeBluCore;
using CodeBlu.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeBlu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CodeBluingDbContext _dbContext;

        public UsersController(CodeBluingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<UsersController>
        //[HttpGet]
        //public IEnumerable<UserDTO> Get()
        //{
        //    List<User> usuarios= _dbContext.Usuarios.AsNoTracking().ToList();
        //    List<UserDTO> usersDTO = new List<UserDTO>();
        //    foreach (User u in usuarios)
        //    {
        //        UserDTO userDTO = new UserDTO()
        //        {
        //            Usuario = u.Usuario,
        //            Contrasena = u.Contrasena
        //        };
        //        usersDTO.Add(userDTO);
        //    }
        //    return usersDTO;
        //}

        // GET api/<UsersController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UsersController>
        //[HttpPost]
        public ActionResult<string> Post([FromBody] UserDTO value)
        {
            User? user = _dbContext.Usuarios.SingleOrDefault(u => u.Usuario == value.Usuario);

            if (value.Contrasena == user?.Contrasena)
            {
                string token = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{user.Usuario} {user.Contrasena}"));
                return Ok(token);
            }
            else
            {
                return Forbid();
            }
        }

        //// PUT api/<UsersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UsersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
