using WSSistemaUniversitario.Models;

namespace WSSistemaUniversitario.Tools
{
    public class BuscarAlumno
    {
        private readonly DbSistemauniversitarioContext _db;
        public BuscarAlumno(DbSistemauniversitarioContext db)
        {
            _db = db;
        }
        public Alumno BuscarUnAlumno(int id)
        {
            return _db.Alumno.FirstOrDefault(a => a.IdAlumno == id);
        }
    }
}
