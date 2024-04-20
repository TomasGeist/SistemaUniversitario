using System;
using System.Collections.Generic;

namespace WSSistemaUniversitario.Models;

public partial class Condicion
{
    public int IdCondicion { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
