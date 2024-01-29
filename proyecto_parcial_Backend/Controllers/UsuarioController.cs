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
    public class UsuarioController : ControllerBase
    {
        public readonly proyecto_parcialContext _dbcontext;

        public UsuarioController(proyecto_parcialContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                lista = _dbcontext.Usuarios.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }

        [HttpGet]
        [Route("Obtener/{IdUsuario:int}")]
        public IActionResult Obtener(int IdUsuario)
        {
            Usuario oUsuario = _dbcontext.Usuarios.Find(IdUsuario);

            if (oUsuario == null)
            {
                return BadRequest("Usuario no encontrado");
            }

            try
            {
                oUsuario = _dbcontext.Usuarios.Where(p => p.IdUsuario == IdUsuario).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oUsuario });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oUsuario });
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Usuario objeto)
        {
            

            try
            {
                _dbcontext.Usuarios.Add(objeto);
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
        public IActionResult Editar([FromBody] Usuario objeto)
        {
            Usuario oUsuario = _dbcontext.Usuarios.Find(objeto.IdUsuario);

            if (oUsuario == null)
            {
                return BadRequest("Usuario no encontrado");
            }

            try
            {
                oUsuario.Nombre = objeto.Nombre is null ? oUsuario.Nombre : objeto.Nombre;
                oUsuario.Correo = objeto.Correo is null ? oUsuario.Correo : objeto.Correo;
                oUsuario.Contraseña = objeto.Contraseña is null ? oUsuario.Contraseña : objeto.Contraseña;
                oUsuario.Telefono = objeto.Telefono is null ? oUsuario.Telefono : objeto.Telefono;
               

                _dbcontext.Usuarios.Update(oUsuario);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }


        [HttpDelete]
        [Route("Eliminar/{IdUsuario:int}")]
        public IActionResult Eliminar(int IdUsuario)
        {
            Usuario oUsuario = _dbcontext.Usuarios.Find(IdUsuario);

            if (oUsuario == null)
            {
                return BadRequest("Usuario no encontrado");
            }

            try
            {
                _dbcontext.Usuarios.Remove(oUsuario);
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
