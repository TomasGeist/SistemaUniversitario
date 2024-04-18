using System;
using System.Collections.Generic;

namespace WSSistemaUniversitario.Models;

public partial class AlumnoMateria
{
    public int IdAlumnoMateria { get; set; }

    public int AñoDeCursado { get; set; }

    public int IdAlumno { get; set; }

    public int IdMateria { get; set; }

    public virtual Alumno IdAlumnoNavigation { get; set; } = null!;

    public virtual Materia IdMateriaNavigation { get; set; } = null!;
}
