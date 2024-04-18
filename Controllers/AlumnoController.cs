using Microsoft.AspNetCore.Mvc;
using WSSistemaUniversitario.Models;

namespace WSSistemaUniversitario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : Controller
    {
        private readonly DbSistemauniversitarioContext _db;

        public AlumnoController(DbSistemauniversitarioContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lst = new List<Alumno>();
            try
            {
              lst = _db.Alumno.ToList();
              return Ok(lst);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
