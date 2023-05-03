using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTSEventsApi.Core.Entities;
using PTSEventsApi.Core.Repositories;
using PTSEventsApi.Data;
using PTSEventsApi.Data.Repositories;

namespace PTSEventsApi.Controllers
{
    [Route("api/ptsevents")]
    [ApiController]
    [Produces("application/json")]
    public class PtsEventController : ControllerBase
    {
        private readonly PTSEventsContext _db;

        private IUnitOfWork _uow;

        public PtsEventController(PTSEventsContext db)
        {
            _uow = new UnitOfWork(db);
            _db = db;
        }


        
        [HttpGet]
        [Route("{name}/participants?includeParticipants={includeParticipants}")]
        public async Task<ActionResult<IEnumerable<PTSEvent>>> GetPTSEventByName(string name, bool includeParticipants=false)
        {            
            if(string.IsNullOrWhiteSpace(name))
            {
                return BadRequest();
            }
            var ptsevent = await _uow.Events.GetAsync(name, includeParticipants);
            if (ptsevent == null)
            {
                return NotFound();
            }

            return Ok(ptsevent);
        }


        // GET: api/PtsEvent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PTSEvent>>> GetPTSEvent()
        {
          if (_db.PTSEventItems == null)
          {
              return NotFound();
          }
            return await _db.PTSEventItems.ToListAsync();
        }

        // GET: api/PtsEvent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PTSEvent>> GetPTSEvent(long id)
        {
          if (_db.PTSEventItems == null)
          {
              return NotFound();
          }
            var pTSEvent = await _db.PTSEventItems.FindAsync(id);

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

            _db.Entry(pTSEvent).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
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
          if (_db.PTSEventItems == null)
          {
              return Problem("Entity set 'PTSEventsApiContext.PTSEvent'  is null.");
          }
            _db.PTSEventItems.Add(pTSEvent);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetPTSEvent", new { id = pTSEvent.Id }, pTSEvent);
        }

        // DELETE: api/PtsEvent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePTSEvent(long id)
        {
            if (_db.PTSEventItems == null)
            {
                return NotFound();
            }
            var pTSEvent = await _db.PTSEventItems.FindAsync(id);
            if (pTSEvent == null)
            {
                return NotFound();
            }

            _db.PTSEventItems.Remove(pTSEvent);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool PTSEventExists(long id)
        {
            return (_db.PTSEventItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
