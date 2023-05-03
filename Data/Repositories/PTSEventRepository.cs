using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PTSEventsApi.Core.Entities;
using PTSEventsApi.Core.Repositories;


namespace PTSEventsApi.Data.Repositories
{
    public class PTSEventRepository : IPTSEventRepository
    {
        private readonly PTSEventsContext _db;

        public PTSEventRepository(PTSEventsContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<PTSEvent>> GetAllAsync()
        {
            return await _db.PTSEventItems.ToListAsync();
        }
        public async Task AddAsync(PTSEvent ptsevent)
        {
            await _db.PTSEventItems.AddAsync(ptsevent);
        }
        public async Task<PTSEvent?> FindByIdAsync(long id)
        {
            return await _db.PTSEventItems.FindAsync(id);
        }
        public async Task<PTSEvent?> GetAsync(string name, bool includeParticipants = false)
        {
            if (includeParticipants)
            {
                return await _db.PTSEventItems
                    .Include(p => p.Participants)
                    .SingleOrDefaultAsync(p => p.Name == name);
            }
            return await _db.PTSEventItems
                .SingleOrDefaultAsync(p => p.Name == name);
        }
        public async Task<PTSEvent?> GetAsync(long id, bool includeParticipants = false)
        {
            if (includeParticipants)
            {
                return await _db.PTSEventItems
                    .Include(p => p.Participants)
                    .SingleOrDefaultAsync(p => p.Id == id);
            }
            return await _db.PTSEventItems
                .SingleOrDefaultAsync(p => p.Id == id);
        }

    }
}