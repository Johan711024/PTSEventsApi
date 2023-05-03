using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTSEventsApi.Core.Entities;

namespace PTSEventsApi.Core.Repositories
{
    public interface IParticipantRepository
    {
        Task AddAsync(Participant participant);
        Task<IEnumerable<Participant>> GetAllAsync();
        Task<Participant> FindByIdAsync(long id);


    }
}