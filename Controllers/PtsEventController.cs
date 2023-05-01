using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTSEventsApi.Models;

namespace PTSEventsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PtsEventController : ControllerBase
    {
        private readonly PTSEventsApiContext _context;

        public PtsEventController(PTSEventsApiContext context)
        {
            _context = context;
        }

        // GET: api/PtsEvent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PTSEvent>>> GetPTSEvent()
        {
          if (_context.PTSEvent == null)
          {
              return NotFound();
          }
            return await _context.PTSEvent.ToListAsync();
        }

        // GET: api/PtsEvent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PTSEvent>> GetPTSEvent(long id)
        {
          if (_context.PTSEvent == null)
          {
              return NotFound();
          }
            var pTSEvent = await _context.PTSEvent.FindAsync(id);

            if (pTSEvent == null)
            {
                return NotFound();
            }

            return pTSEvent;
        }

        // PUT: api/PtsEvent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPTSEvent(long id, PTSEvent pTSEvent)
        {
            if (id != pTSEvent.Id)
            {
                return BadRequest();
            }

            _context.Entry(pTSEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PTSEventExists(id))
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

        // POST: api/PtsEvent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PTSEvent>> PostPTSEvent(PTSEvent pTSEvent)
        {
          if (_context.PTSEvent == null)
          {
              return Problem("Entity set 'PTSEventsApiContext.PTSEvent'  is null.");
          }
            _context.PTSEvent.Add(pTSEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPTSEvent", new { id = pTSEvent.Id }, pTSEvent);
        }

        // DELETE: api/PtsEvent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePTSEvent(long id)
        {
            if (_context.PTSEvent == null)
            {
                return NotFound();
            }
            var pTSEvent = await _context.PTSEvent.FindAsync(id);
            if (pTSEvent == null)
            {
                return NotFound();
            }

            _context.PTSEvent.Remove(pTSEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PTSEventExists(long id)
        {
            return (_context.PTSEvent?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
