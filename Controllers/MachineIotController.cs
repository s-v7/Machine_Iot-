using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MachineWebApi.Models;

namespace MachineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineIotController : ControllerBase
    {
        private readonly MachineIotContext _context;

        public MachineIotController(MachineIotContext context)
        {
            _context = context;
        }

        // GET: api/MachineIot
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MachineIot>>> GetmachineIots()
        {
          if (_context.machineIots == null)
          {
              return NotFound();
          }
            return await _context.machineIots.ToListAsync();
        }

        // GET: api/MachineIot/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MachineIot>> GetMachineIot(string id)
        {
          if (_context.machineIots == null)
          {
              return NotFound();
          }
            var machineIot = await _context.machineIots.FindAsync(id);

            if (machineIot == null)
            {
                return NotFound();
            }

            return machineIot;
        }

        // PUT: api/MachineIot/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMachineIot(string id, MachineIot machineIot)
        {
            if (id != machineIot.Id)
            {
                return BadRequest();
            }

            _context.Entry(machineIot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineIotExists(id))
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

        // POST: api/MachineIot
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MachineIot>> PostMachineIot(MachineIot machineIot)
        {
          if (_context.machineIots == null)
          {
              return Problem("Entity set 'MachineIotContext.machineIots'  is null.");
          }
            _context.machineIots.Add(machineIot);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MachineIotExists(machineIot.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMachineIot", new { id = machineIot.Id }, machineIot);
        }

        // DELETE: api/MachineIot/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachineIot(string id)
        {
            if (_context.machineIots == null)
            {
                return NotFound();
            }
            var machineIot = await _context.machineIots.FindAsync(id);
            if (machineIot == null)
            {
                return NotFound();
            }

            _context.machineIots.Remove(machineIot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MachineIotExists(string id)
        {
            return (_context.machineIots?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
