using WSSistemaUniversitario.DTOs;
using WSSistemaUniversitario.Models.Response;

namespace WSSistemaUniversitario.Services
{
    public interface IAlumnoService
    {
        public Respuesta ObtenerAlumnos();

        public Respuesta EliminarAlumno(int id);

        public Respuesta EditarAlumno(EditarAlumnoDTO model);

        public Respuesta EditarCondicionAlumno(CambioDeCondicionAlumnoDTO dto);

        public Respuesta GenerarPago(int id);

        public Respuesta ActualizarSaldo(int id);

        public Respuesta CambiarCorreo(int id, string nuevocorreo);
    }
}
