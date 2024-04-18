using System;
using System.Collections.Generic;

namespace WSSistemaUniversitario.Models;

public partial class Cuota
{
    public int IdCuota { get; set; }

    public decimal Costo { get; set; }

    public int IdCarrera { get; set; }

    public virtual Carrera IdCarreraNavigation { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
