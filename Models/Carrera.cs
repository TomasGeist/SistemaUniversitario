using System;
using System.Collections.Generic;

namespace WSSistemaUniversitario.Models;

public partial class Carrera
{
    public int IdCarrera { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Director { get; set; }

    public virtual ICollection<Cuota> Cuota { get; set; } = new List<Cuota>();

    public virtual ICollection<Materia> Materia { get; set; } = new List<Materia>();

    public virtual ICollection<PlanDeEstudio> PlanDeEstudios { get; set; } = new List<PlanDeEstudio>();
}
