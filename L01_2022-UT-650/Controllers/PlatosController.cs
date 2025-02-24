﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L01_2022_UT_650.Data;
using L01_2022_UT_650.Models;

namespace L01_2022_UT_650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatosController : ControllerBase
    {
        private readonly RestauranteDbContext _context;

        public PlatosController(RestauranteDbContext context)
        {
            _context = context;
        }

        // GET: api/Platos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plato>>> GetPlatos()
        {
            return await _context.Platos.ToListAsync();
        }

        // GET: api/Platos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plato>> GetPlato(int id)
        {
            var plato = await _context.Platos.FindAsync(id);

            if (plato == null)
            {
                return NotFound();
            }

            return plato;
        }

        // PUT: api/Platos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlato(int id, Plato plato)
        {
            if (id != plato.PlatoId)
            {
                return BadRequest();
            }

            _context.Entry(plato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatoExists(id))
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

        // POST: api/Platos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plato>> PostPlato(Plato plato)
        {
            _context.Platos.Add(plato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlato", new { id = plato.PlatoId }, plato);
        }

        // DELETE: api/Platos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlato(int id)
        {
            var plato = await _context.Platos.FindAsync(id);
            if (plato == null)
            {
                return NotFound();
            }

            _context.Platos.Remove(plato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlatoExists(int id)
        {
            return _context.Platos.Any(e => e.PlatoId == id);
        }
    }
}
