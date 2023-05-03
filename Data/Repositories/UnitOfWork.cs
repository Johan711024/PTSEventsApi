using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTSEventsApi.Core.Repositories;

namespace PTSEventsApi.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PTSEventsContext _db;
        public IPTSEventRepository Events { get; private set; }
        public IParticipantRepository Participant { get; private set; }
        public UnitOfWork(PTSEventsContext db)
        {
            _db = db;
            Events = new PTSEventRepository(_db);
            Participant = new ParticipantRepository(_db);
        }

        public async Task CompleteAsync()
        {
            await _db.SaveChangesAsync();
        }

    }
}