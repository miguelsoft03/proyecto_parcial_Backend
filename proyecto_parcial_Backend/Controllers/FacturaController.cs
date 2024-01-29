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
    public class FacturaController : ControllerBase
    {
        public readonly proyecto_parcialContext _dbcontext;

        public FacturaController(proyecto_parcialContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Factura> lista = new List<Factura>();
             
            try
            {
                lista = _dbcontext.Facturas.Include(c => c.oCita).Include(c => c.oMascota).Include(c => c.oUsuario).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }

        [HttpGet]
        [Route("Obtener/{IdFactura:int}")]
        public IActionResult Obtener(int IdFactura)
        {
            Factura oFactura = _dbcontext.Facturas.Find(IdFactura);

            if (oFactura == null)
            {
                return BadRequest("Factura no encontrado");
            }

            try
            {
                oFactura = _dbcontext.Facturas.Include(c => c.oCita).Include(c => c.oMascota).Include(c => c.oUsuario).Where(p => p.IdFactura == IdFactura).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oFactura });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oFactura });
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Factura objeto)
        {
            Cita oCita = _dbcontext.Cita.Find(objeto.IdCita);

            if (oCita == null)
            {
                return BadRequest("Cita no encontrado");

            }

            Mascota oMascota = _dbcontext.Mascota.Find(objeto.IdMascota);

            if (oMascota == null)
            {
                return BadRequest("Mascota no encontrado");
            }

            Usuario oUsuario = _dbcontext.Usuarios.Find(objeto.IdUsuario);

            if (oUsuario == null)
            {
                return BadRequest("Usuario no encontrado");
            }

            try
            {
                _dbcontext.Facturas.Add(objeto);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Factura objeto)
        {
            Factura oFactura = _dbcontext.Facturas.Find(objeto.IdFactura);

            if (oFactura == null)
            {
                return BadRequest("Factura no encontrado");
            }

            try
            {
                oFactura.IdUsuario = objeto.IdUsuario is null ? oFactura.IdUsuario : objeto.IdUsuario;
                oFactura.Nombre = objeto.Nombre is null ? oFactura.Nombre : objeto.Nombre;
                oFactura.Correo = objeto.Correo is null ? oFactura.Correo : objeto.Correo;
                oFactura.IdMascota = objeto.IdMascota is null ? oFactura.IdMascota : objeto.IdMascota;
                oFactura.NombrePet = objeto.NombrePet is null ? oFactura.NombrePet : objeto.NombrePet;
                oFactura.IdCita = objeto.IdCita is null ? oFactura.IdCita : objeto.IdCita;
                oFactura.FechaCita = objeto.FechaCita is Nullable? oFactura.FechaCita : objeto.FechaCita;
                oFactura.Especialidad = objeto.Especialidad is null ? oFactura.Especialidad : objeto.Especialidad;
                oFactura.Costos = objeto.Costos  is null ? oFactura.Costos : objeto.Costos;

                _dbcontext.Facturas.Update(oFactura);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }


        [HttpDelete]
        [Route("Eliminar/{IdFactura:int}")]
        public IActionResult Eliminar(int IdFactura)
        {
            Factura oFactura = _dbcontext.Facturas.Find(IdFactura);

            if (oFactura == null)
            {
                return BadRequest("Factura no encontrado");
            }

            try
            {
                _dbcontext.Facturas.Remove(oFactura);
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
