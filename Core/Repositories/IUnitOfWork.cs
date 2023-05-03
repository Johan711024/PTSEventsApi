using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSEventsApi.Core.Repositories
{
    public interface IUnitOfWork
    {
        IPTSEventRepository Events { get; }
        IParticipantRepository Participant { get; }

        Task CompleteAsync();
    }
}