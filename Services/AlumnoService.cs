using Microsoft.EntityFrameworkCore;
using WSSistemaUniversitario.DTOs;
using WSSistemaUniversitario.Models;
using WSSistemaUniversitario.Models.Response;

namespace WSSistemaUniversitario.Services
{
    public class AlumnoService
    {
        private readonly DbSistemauniversitarioContext _db;
        private Respuesta _resp;
        public AlumnoService(DbSistemauniversitarioContext db, Respuesta resp)
        {
            _db = db;
            _resp = resp;
        }

        public Respuesta ObtenerAlumnos()
        {
            try
            {
                var lst = _db.Alumno.ToList();
                if (lst.Count != 0)
                {
                    _resp.data = lst;
                    _resp.codigo = 1;
                    _resp.descripcion = "Alumnos encontrados con éxito";
                    return _resp;
                }
                else
                {
                    throw (new Exception("No se encontraron Alumnos en la BDD"));
                }
            } catch(Exception ex)
            {
                _resp.descripcion = ex.Message;
                return _resp;
            }
        }

        public Respuesta EliminarAlumno() { return _resp; }
        public Respuesta EditarAlumno() { return _resp;  }
        public Respuesta EditarCondicionAlumno(CambioDeCondicionAlumnoDTO dto) {
            var alumno = _db.Alumno.FirstOrDefault(a => a.IdAlumno == dto.idAlumno);
            if (alumno != null)
            {
                    try
                    {
                        if (dto.Condicion < 1 || dto.Condicion > _db.Condicion.ToList().Count())
                        {
                            throw new Exception("No puedes asignar una condición inexistente");
                        }
                    else
                    {
                    

                        alumno.Condicion = dto.Condicion;
                        _db.SaveChanges();
                        _resp.descripcion = "Condicion cambiada con éxito";
                        _resp.codigo = 1;
                        return _resp;
                        
                    }
                    }
                    catch (Exception ex)
                    {
                        _resp.descripcion = ex.Message;
                        return _resp;
                    }
                }
            else {
                    _resp.descripcion = "No se encontró ningun alumno";
                    return _resp;
                }
        }
        public Respuesta RealizarPago() { return _resp; }

    }
}
