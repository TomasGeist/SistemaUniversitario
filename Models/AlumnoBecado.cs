using System;
using System.Collections.Generic;

namespace WSSistemaUniversitario.Models;

public partial class AlumnoBecado
{
    public int IdAlumnoBecado { get; set; }

    public DateOnly FechaDeInicio { get; set; }

    public int IdAlumno { get; set; }

    public int IdBeca { get; set; }

    public virtual Alumno IdAlumnoNavigation { get; set; } = null!;

    public virtual Beca IdBecaNavigation { get; set; } = null!;
}
