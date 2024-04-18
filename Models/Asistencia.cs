using System;
using System.Collections.Generic;

namespace WSSistemaUniversitario.Models;

public partial class Asistencia
{
    public int IdAsistencia { get; set; }

    public DateOnly Fecha { get; set; }

    public int IdAlumno { get; set; }

    public int IdMateria { get; set; }

    public virtual Alumno IdAlumnoNavigation { get; set; } = null!;

    public virtual Materia IdMateriaNavigation { get; set; } = null!;
}
