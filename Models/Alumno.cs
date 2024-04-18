using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WSSistemaUniversitario.Models;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int IdCarrera { get; set; }

    public string Condicion { get; set; } = null!;

    public string Password { get; set; } = null!;

    public decimal Saldo { get; set; }

    [JsonIgnore]
    public virtual ICollection<AlumnoBecado> AlumnoBecados { get; set; } = new List<AlumnoBecado>();

    [JsonIgnore]
    public virtual ICollection<AlumnoMateria> AlumnoMateria { get; set; } = new List<AlumnoMateria>();

    [JsonIgnore]
    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    [JsonIgnore]
    public virtual ICollection<Examen> Examen { get; set; } = new List<Examen>();

    [JsonIgnore]
    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
