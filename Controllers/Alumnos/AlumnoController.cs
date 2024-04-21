using Microsoft.AspNetCore.Mvc;
using WSSistemaUniversitario.DTOs;
using WSSistemaUniversitario.Models;
using WSSistemaUniversitario.Services;
using WSSistemaUniversitario.Tools;

namespace WSSistemaUniversitario.Controllers.Alumnos
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : Controller
    {
        private readonly AlumnoService _alumno;
        private readonly CambioDeCondicionAlumnoDTO _dtoCambioCondicion;
        private readonly Verificaciones _verificaciones;

        public AlumnoController(AlumnoService alumno, CambioDeCondicionAlumnoDTO dtoCambioCondicion, Verificaciones verificaciones)
        {
            _alumno = alumno;
            _dtoCambioCondicion = dtoCambioCondicion;
            _verificaciones = verificaciones;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var rsp = _alumno.ObtenerAlumnos();
            return (rsp.codigo == 0) ? BadRequest(rsp) : Ok(rsp);
        }


        [HttpDelete]

        public IActionResult Delete([FromBody] int id)
        {
            var rsp = _alumno.EliminarAlumno(id);
            return (rsp.codigo == 0) ? BadRequest(rsp) : Ok(rsp);

        }


        [HttpPut("/condicion")]

        public IActionResult CambiarCondicion([FromBody] CambioDeCondicionAlumnoDTO _dtoCambioCondicion)
        {
           
            
                var rsp = _alumno.EditarCondicionAlumno(_dtoCambioCondicion);
                return (rsp.codigo == 0) ? BadRequest(rsp) : Ok(rsp);
            
        }
    }
}
