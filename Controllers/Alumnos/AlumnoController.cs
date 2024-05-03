using Microsoft.AspNetCore.Mvc;
using WSSistemaUniversitario.DTOs;
using WSSistemaUniversitario.Models;
using WSSistemaUniversitario.Models.Response;
using WSSistemaUniversitario.Services;
using WSSistemaUniversitario.Tools;

namespace WSSistemaUniversitario.Controllers.Alumnos
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : Controller
    {
        private readonly IAlumnoService _alumno;
        private readonly Verificaciones _verificaciones;
        private readonly EnviarEmailController _enviarEmail;
        public AlumnoController(IAlumnoService alumno, Verificaciones verificaciones, EnviarEmailController enviarEmail)
        {
            _alumno = alumno;
            _verificaciones = verificaciones;
            _enviarEmail = enviarEmail;
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

        [HttpPut]

        public IActionResult Edit([FromBody] EditarAlumnoDTO alumno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var rsp = _alumno.EditarAlumno(alumno);
                return (rsp.codigo == 0) ? BadRequest(rsp) : Ok(rsp);
            }
            
        }


        [HttpPut("/condicion")]

        public IActionResult CambiarCondicion([FromBody] CambioDeCondicionAlumnoDTO _dtoCambioCondicion)
        {
                var rsp = _alumno.EditarCondicionAlumno(_dtoCambioCondicion);
                return (rsp.codigo == 0) ? BadRequest(rsp) : Ok(rsp);
        }

        [HttpPost("/confirmarpago")]
        public IActionResult ConfirmarPago([FromBody] int id)
        {
            
            var rsp = _alumno.GenerarPago(id);
            if (rsp.codigo == 0)
            {
                return BadRequest(rsp);
            }
            else
            {
                ActualizarSaldo(id, rsp);
                _enviarEmail.EnviarCorreo(new EmailDTO(), id);
                return Ok(rsp);
            }
        }

        [HttpPut("/actualizarsaldo")]

        private IActionResult ActualizarSaldo(int id, Respuesta respuesta)
        {
            if (respuesta.codigo == 0)
            {
                return BadRequest(respuesta);
            }
            else
            {
                var rsp = _alumno.ActualizarSaldo(id);
                return (rsp.codigo == 0) ? BadRequest(rsp) : Ok(rsp);
            }          
        }
    }
}
