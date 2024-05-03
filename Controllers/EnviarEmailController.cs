using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSSistemaUniversitario.DTOs;
using WSSistemaUniversitario.Services;

namespace WSSistemaUniversitario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class EnviarEmailController : ControllerBase
    {
        private readonly IEmailService _email;
        private readonly IPdfPagoService _pdfPagoService;

        public EnviarEmailController(IEmailService email, IPdfPagoService pdfPagoService)
        {
            _email = email;
            _pdfPagoService = pdfPagoService;
        }

        [HttpPost]

        public IActionResult EnviarCorreo(EmailDTO correo, int id)
        {
            correo.IdAlumno = id;
            var stream = _pdfPagoService.generarPdf(correo.IdAlumno);
            _email.EnviarEmail(correo, stream);
            return Ok();
        }

    }
}
