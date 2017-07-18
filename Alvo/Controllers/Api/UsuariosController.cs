using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Alvo.Data;
using Microsoft.EntityFrameworkCore;
using Alvo.Models;

namespace Alvo.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Usuarios")]
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET /api/usuarios
        [Route("~/api/usuarios")]
        public ActionResult GetUsuarios(string query = null)
        {
            var usuariosQuery = _context.Usuarios.Select(u => u);

            if (!String.IsNullOrWhiteSpace(query))
                usuariosQuery = usuariosQuery.Where(u => u.Nome.Contains(query));

            return Ok(usuariosQuery.ToList());
        }

        // GET /api/usuarios/1
        [Route("~/api/usuarios/{id}")]
        public ActionResult GetUsuario(int id)
        {
            var usuario = _context.Usuarios.Include( u=> u.Jogos).SingleOrDefault(u => u.Id == id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        // POST /api/customers
        [HttpPost]
        public ActionResult CreateUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return Created(("/" + usuario.Id), usuario);
        }

        // PUT /api/usuarios/1
        [HttpPut]
        public ActionResult UpdateUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var usuarioInDb = _context.Usuarios.SingleOrDefault(c => c.Id == id);

            if (usuarioInDb == null)
                return NotFound();

            usuarioInDb.Nome = usuario.Nome;
            usuarioInDb.Email = usuario.Email;
            usuarioInDb.Telefone = usuario.Telefone;

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/usuarios/1
        [HttpDelete]
        public ActionResult DeleteUsuario(int id)
        {
            var usuarioInDb = _context.Usuarios.SingleOrDefault(c => c.Id == id);

            if (usuarioInDb == null)
                return NotFound();

            _context.Usuarios.Remove(usuarioInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}