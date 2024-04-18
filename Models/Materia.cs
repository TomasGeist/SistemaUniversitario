using System;
using System.Collections.Generic;

namespace WSSistemaUniversitario.Models;

public partial class Materia
{
    public int IdMateria { get; set; }

    public int IdCarrera { get; set; }

    public int Cupo { get; set; }

    public string Nombre { get; set; } = null!;

    public string HoraDeInicio { get; set; } = null!;

    public string HoraDeFinal { get; set; } = null!;

    public int Semestre { get; set; }

    public int Año { get; set; }

    public int IdPlanDeEstudio { get; set; }

    public virtual ICollection<AlumnoMateria> AlumnoMateria { get; set; } = new List<AlumnoMateria>();

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual ICollection<Examen> Examen { get; set; } = new List<Examen>();

    public virtual Carrera IdCarreraNavigation { get; set; } = null!;

    public virtual PlanDeEstudio IdPlanDeEstudioNavigation { get; set; } = null!;

    public virtual ICollection<ProfesorMateria> ProfesorMateria { get; set; } = new List<ProfesorMateria>();
}
