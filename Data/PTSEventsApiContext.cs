using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PTSEventsApi.Models;

    public class PTSEventsApiContext : DbContext
    {
        public PTSEventsApiContext (DbContextOptions<PTSEventsApiContext> options)
            : base(options)
        {
        }

        public DbSet<PTSEventsApi.Models.PTSEvent> PTSEvent { get; set; } = default!;

        public DbSet<PTSEventsApi.Models.Participant> Participant { get; set; } = default!;
    }
