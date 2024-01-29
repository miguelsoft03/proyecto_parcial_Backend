using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using proyecto_parcial_Backend.Models;
using System;

using Microsoft.AspNetCore.Cors;


namespace proyecto_parcial_Backend.Controllers
{
    [EnableCors("ReglasCors ")]
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        public readonly proyecto_parcialContext _dbcontext;

        public CitaController(proyecto_parcialContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Cita> lista = new List<Cita>();

            try
            {
                lista = _dbcontext.Cita.Include(c => c.oMascota).Include(c => c.oUsuario).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }

        [HttpGet]
        [Route("Obtener/{IdCita:int}")]
        public IActionResult Obtener(int IdCita)
        {
            Cita oCita = _dbcontext.Cita.Find(IdCita);

            if(oCita == null)
            {
                return BadRequest("Cita no encontrado");
            }

            try
            {
                oCita = _dbcontext.Cita.Include(c => c.oMascota).Include(c => c.oUsuario).Where(p => p.IdCita == IdCita).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oCita });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oCita });
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Cita objeto)
        {
            Usuario oUsuario = _dbcontext.Usuarios.Find(objeto.IdUsuario);

            if (oUsuario == null)
            {
                return BadRequest("Usuario no encontrado");

            }

            Mascota oMascota = _dbcontext.Mascota.Find(objeto.IdMascota);

            if (oMascota == null)
            {
                return BadRequest("Mascota no encontrado");
            }

            try
            {
                _dbcontext.Cita.Add(objeto);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message});
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Cita objeto)
        {
            Cita oCita = _dbcontext.Cita.Find(objeto.IdCita);

            if (oCita == null)
            {
                return BadRequest("Cita no encontrado");
            }

            try
            {
                oCita.IdUsuario = objeto.IdUsuario is null ? oCita.IdUsuario : objeto.IdUsuario;
                oCita.Nombre = objeto.Nombre is null ? oCita.Nombre : objeto.Nombre;
                oCita.Correo = objeto.Correo is null ? oCita.Correo : objeto.Correo;
                oCita.IdMascota = objeto.IdMascota is null ? oCita.IdMascota : objeto.IdMascota;
                oCita.NombrePet = objeto.NombrePet is null ? oCita.NombrePet : objeto.NombrePet;
                oCita.Ciudad = objeto.Ciudad is null ? oCita.Ciudad : objeto.Ciudad;
                oCita.Especialidad = objeto.Especialidad is null ? oCita.Especialidad : objeto.Especialidad;
                oCita.Sucursal = objeto.Sucursal is null ? oCita.Sucursal : objeto.Sucursal;
                oCita.Mes = objeto.Mes is null ? oCita.Mes : objeto.Mes;
                oCita.Dia = objeto.Dia is null ? oCita.Dia : objeto.Dia;

                _dbcontext.Cita.Update(oCita);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }


        [HttpDelete]
        [Route("Eliminar/{IdCita:int}")]
        public IActionResult Eliminar(int IdCita)
        {
            Cita oCita = _dbcontext.Cita.Find(IdCita);

            if (oCita == null)
            {
                return BadRequest("Cita no encontrado");
            }

            try
            {
                _dbcontext.Cita.Remove(oCita);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }


    }
}
