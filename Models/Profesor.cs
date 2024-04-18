using System;
using System.Collections.Generic;

namespace WSSistemaUniversitario.Models;

public partial class Profesor
{
    public int IdProfesor { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public virtual ICollection<Examen> Examen { get; set; } = new List<Examen>();

    public virtual ICollection<ProfesorMateria> ProfesorMateria { get; set; } = new List<ProfesorMateria>();
}
