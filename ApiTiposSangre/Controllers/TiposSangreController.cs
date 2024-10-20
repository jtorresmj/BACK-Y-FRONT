using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTiposSangre.Models;

namespace ApiTiposSangre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposSangreController : ControllerBase
    {
        private readonly Conexiones _context;

        public TiposSangreController(Conexiones context)
        {
            _context = context;
        }

        // GET: api/TiposSangre
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tipos_sangre>>> Gettipos_sangre()
        {
            return await _context.tipos_sangre.ToListAsync();
        }

        // GET: api/TiposSangre/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tipos_sangre>> Gettipos_sangre(int id)
        {
            var tipos_sangre = await _context.tipos_sangre.FindAsync(id);

            if (tipos_sangre == null)
            {
                return NotFound();
            }

            return tipos_sangre;
        }

        // PUT: api/TiposSangre/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttipos_sangre(int id, tipos_sangre tipos_sangre)
        {
            if (id != tipos_sangre.id_tipo_sangre)
            {
                return BadRequest();
            }

            _context.Entry(tipos_sangre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tipos_sangreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TiposSangre
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tipos_sangre>> Posttipos_sangre(tipos_sangre tipos_sangre)
        {
            _context.tipos_sangre.Add(tipos_sangre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettipos_sangre", new { id = tipos_sangre.id_tipo_sangre }, tipos_sangre);
        }

        // DELETE: api/TiposSangre/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetipos_sangre(int id)
        {
            var tipos_sangre = await _context.tipos_sangre.FindAsync(id);
            if (tipos_sangre == null)
            {
                return NotFound();
            }

            _context.tipos_sangre.Remove(tipos_sangre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tipos_sangreExists(int id)
        {
            return _context.tipos_sangre.Any(e => e.id_tipo_sangre == id);
        }
    }
}
