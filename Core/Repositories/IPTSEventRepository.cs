using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTSEventsApi.Core.Entities;

namespace PTSEventsApi.Core.Repositories
{
    public interface IPTSEventRepository
    {
        Task AddAsync(PTSEvent ptsevent);
        Task<IEnumerable<PTSEvent>> GetAllAsync();
        Task<PTSEvent> FindByIdAsync(long id);

        Task<PTSEvent?> GetAsync(string name, bool includeParticipants = false);



    }
}