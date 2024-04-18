using System;
using System.Collections.Generic;

namespace WSSistemaUniversitario.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public DateOnly Fecha { get; set; }

    public int IdCuota { get; set; }

    public int IdAlumno { get; set; }

    public virtual Alumno IdAlumnoNavigation { get; set; } = null!;

    public virtual Cuota IdCuotaNavigation { get; set; } = null!;
}
