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
    public class ParticipantController : ControllerBase
    {
        private readonly PTSEventsApiContext _context;

        public ParticipantController(PTSEventsApiContext context)
        {
            _context = context;
        }

        // GET: api/Participant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participant>>> GetParticipant()
        {
          if (_context.Participant == null)
          {
              return NotFound();
          }
            return await _context.Participant.ToListAsync();
        }

        // GET: api/Participant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participant>> GetParticipant(long id)
        {
          if (_context.Participant == null)
          {
              return NotFound();
          }
            var participant = await _context.Participant.FindAsync(id);

            if (participant == null)
            {
                return NotFound();
            }

            return participant;
        }

        // PUT: api/Participant/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipant(long id, Participant participant)
        {
            if (id != participant.Id)
            {
                return BadRequest();
            }

            _context.Entry(participant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(id))
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

        // POST: api/Participant
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Participant>> PostParticipant(Participant participant)
        {
          if (_context.Participant == null)
          {
              return Problem("Entity set 'PTSEventsApiContext.Participant'  is null.");
          }
            _context.Participant.Add(participant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipant", new { id = participant.Id }, participant);
        }

        // DELETE: api/Participant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(long id)
        {
            if (_context.Participant == null)
            {
                return NotFound();
            }
            var participant = await _context.Participant.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }

            _context.Participant.Remove(participant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipantExists(long id)
        {
            return (_context.Participant?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
