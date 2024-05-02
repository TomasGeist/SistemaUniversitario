using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSSistemaUniversitario.Models;
using WSSistemaUniversitario.Models.Response;

namespace WSSistemaUniversitario.Controllers.Profesor
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
    private readonly DbSistemauniversitarioContext _db;

        private Respuesta _resp;

        public ProfesorController(DbSistemauniversitarioContext db, Respuesta resp)
        {
            _db = db;
            _resp = resp;
        }

        [HttpGet]

        public async Task<Respuesta> obtenerProfesores()
        {
            return (_resp);
        }

    }
}
