using System;
using System.Collections.Generic;

namespace WSSistemaUniversitario.Models;

public partial class Examen
{
    public int IdExamen { get; set; }

    public string Tipo { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public decimal Nota { get; set; }

    public int IdAlumno { get; set; }

    public int IdProfesor { get; set; }

    public int IdMateria { get; set; }

    public virtual Alumno IdAlumnoNavigation { get; set; } = null!;

    public virtual Materia IdMateriaNavigation { get; set; } = null!;

    public virtual Profesor IdProfesorNavigation { get; set; } = null!;
}
