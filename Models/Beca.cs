using System;
using System.Collections.Generic;

namespace WSSistemaUniversitario.Models;

public partial class Beca
{
    public int IdBeca { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int? Cupo { get; set; }

    public int? Descuento { get; set; }

    public virtual ICollection<AlumnoBecado> AlumnoBecados { get; set; } = new List<AlumnoBecado>();
}
