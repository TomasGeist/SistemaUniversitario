using System;
using System.Collections.Generic;

namespace WSSistemaUniversitario.Models;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int IdCarrera { get; set; }

    public int Condicion { get; set; }

    public string Password { get; set; } = null!;

    public decimal Saldo { get; set; }

    public virtual ICollection<AlumnoBecado> AlumnoBecados { get; set; } = new List<AlumnoBecado>();

    public virtual ICollection<AlumnoMateria> AlumnoMateria { get; set; } = new List<AlumnoMateria>();

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual Condicion CondicionNavigation { get; set; } = null!;

    public virtual ICollection<Examen> Examen { get; set; } = new List<Examen>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
