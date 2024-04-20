using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSSistemaUniversitario.Models;

namespace WSSistemaUniversitario.Controllers.Profesor
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
    private readonly DbSistemauniversitarioContext _db;
        public ProfesorController(DbSistemauniversitarioContext db)
        {
            _db = db;
        }



        //[HttpGet]

        //public async Task<IActionResult> GetProfesor()
        //{
        //    var lst = new List<T>

        //    try
        //    {
                

        //    }catch (Exception ex)
        //    {

        //    }
        //}

    }
}
