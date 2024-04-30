using Microsoft.EntityFrameworkCore;
using WSSistemaUniversitario.DTOs;
using WSSistemaUniversitario.Models;
using WSSistemaUniversitario.Models.Response;
using WSSistemaUniversitario.Tools;

namespace WSSistemaUniversitario.Services
{
    public class AlumnoService : IAlumnoService
    {
        private readonly DbSistemauniversitarioContext _db;
        private Respuesta _resp;
        private readonly BuscarAlumno _buscarAlumno;
        private readonly RespuestasUtiles _respuestasUtiles;
        public AlumnoService(DbSistemauniversitarioContext db, Respuesta resp, BuscarAlumno buscar, RespuestasUtiles respUtiles)
        {
            _db = db;
            _resp = resp;
            _buscarAlumno = buscar;
            _respuestasUtiles = respUtiles;
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

        public Respuesta EliminarAlumno(int id)
        {
            try
            {
                var alumno = _buscarAlumno.BuscarUnAlumno(id); ;

                if (alumno != null) {
                    _db.Alumno.Remove(alumno);
                    _db.SaveChanges();
                    _resp.descripcion = "Alumno removido con éxito";
                    _resp.codigo = 1;
                    return _resp;
                }
                else
                {
                    _resp.descripcion =     _respuestasUtiles.AlumnoNoEncontrado;
                    return _resp;
                }
                ;
            }
            catch (Exception ex)
            {
                _resp.descripcion= ex.Message;
                return _resp;
            }
        
        }
        public Respuesta EditarAlumno(EditarAlumnoDTO model) {
            var alumno = _buscarAlumno.BuscarUnAlumno(model.Id);
            if (alumno != null)
            {
                try
                {
                    alumno.Nombre = model.Nombre;
                    alumno.Apellido = model.Apellido;
                    alumno.IdCarrera = model.IdCarrera;
                    alumno.Condicion = model.Condicion;
                    _db.SaveChanges();

                    _resp.codigo = 1;
                    _resp.descripcion = "Alumno editado con éxito";
                    return (_resp);

                } catch(Exception ex)
                {
                    _resp.descripcion = ex.Message;
                    return (_resp);
                }
            }
            else
            {
                _resp.descripcion = _respuestasUtiles.AlumnoNoEncontrado;
                return (_resp);
            }
        }
        public Respuesta EditarCondicionAlumno(CambioDeCondicionAlumnoDTO dto) {
            var alumno = _buscarAlumno.BuscarUnAlumno(dto.idAlumno);
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
                    _resp.descripcion = _respuestasUtiles.AlumnoNoEncontrado;
                return _resp;
                }
        }
        public Respuesta GenerarPago(int id) {
            var alumno = _buscarAlumno.BuscarUnAlumno(id);
            var cuota = _db.Cuota.FirstOrDefault(c => c.IdCarrera == alumno.IdCarrera);
            if (alumno != null)
            {
                var pago = new Pago();
                if (cuota != null)
                {
                    pago.IdAlumno = id;
                    pago.IdCuota = cuota.IdCuota;
                    _db.Pago.Add(pago);
                    _db.SaveChanges();
                    _resp.descripcion = "Pago Confirmado";
                    _resp.codigo = 1;
                    return _resp;
                }
                else
                {
                    _resp.descripcion = "Hubo un error con la cuota";
                    return _resp;
                }
            }
            else
            {
                _resp.descripcion = _respuestasUtiles.AlumnoNoEncontrado;
                return _resp;
            }  
        }


        public Respuesta ActualizarSaldo(int id)
        {
            var alumno = _buscarAlumno.BuscarUnAlumno(id);
            var cuota = _db.Cuota.FirstOrDefault(c => c.IdCarrera == alumno.IdCarrera);
            if (alumno.Saldo < 0)
            {
                try
                {
                    alumno.Saldo += cuota.Costo;
                    _db.SaveChanges();
                    _resp.descripcion = "Saldo Actualizado";
                    _resp.codigo = 1;
                    return _resp;
                }
                catch (Exception ex)
                {
                    _resp.descripcion = ex.Message;
                    return _resp;
                }
            }
            else {
                _resp.descripcion = "Saldo Actualizado";
                _resp.codigo = 1;
                return _resp;
            }
        }

        public Respuesta CambiarCorreo(int id, string nuevocorreo)
        {
            var alumno = _buscarAlumno.BuscarUnAlumno(id);
            try
            {
                alumno.Correo = nuevocorreo;
                _db.SaveChanges();
                _resp.codigo = 1;
                _resp.descripcion = "Correo Actualizado";
                return (_resp);
            } catch (Exception ex)
            {
                _resp.descripcion= ex.Message;
                return _resp;
            }

        }
    }
}
