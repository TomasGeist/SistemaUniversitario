using System.ComponentModel.DataAnnotations;

namespace WSSistemaUniversitario.DTOs
{
    public class CambioDeCondicionAlumnoDTO
    {
        [Required(ErrorMessage = "Este campo es requerido y no puede ser un string")]
        public int idAlumno {  get; set; }

        public int Condicion {get; set;}
    }
}
