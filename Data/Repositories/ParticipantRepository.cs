using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PTSEventsApi.Data;
using PTSEventsApi.Core.Entities;
using PTSEventsApi.Core.Repositories;

namespace PTSEventsApi.Data.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly PTSEventsContext _db;
        public ParticipantRepository(PTSEventsContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Participant>> GetAllAsync()
        {
            return await _db.Participants.ToListAsync();
        }
        public async Task AddAsync(Participant participant)
        {
            await _db.Participants.AddAsync(participant);
        }
        public async Task<Participant?> FindByIdAsync(long id)
        {
            return await _db.Participants.FindAsync(id);
        }

    }
}