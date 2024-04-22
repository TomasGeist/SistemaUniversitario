using System.ComponentModel.DataAnnotations;

namespace WSSistemaUniversitario.DTOs
{
    public class EditarAlumnoDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public int IdCarrera { get; set; }

        public int Condicion { get; set; }

    }
}
