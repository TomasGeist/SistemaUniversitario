using System;
using System.Collections.Generic;

namespace WSSistemaUniversitario.Models;

public partial class PlanDeEstudio
{
    public int IdPlanDeEstudio { get; set; }

    public DateOnly FechaDeCreacion { get; set; }

    public int IdCarrera { get; set; }

    public virtual Carrera IdCarreraNavigation { get; set; } = null!;

    public virtual ICollection<Materia> Materia { get; set; } = new List<Materia>();
}
