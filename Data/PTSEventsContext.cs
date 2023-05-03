using Microsoft.EntityFrameworkCore;
using PTSEventsApi.Core.Entities;

namespace PTSEventsApi.Data;

public class PTSEventsContext : DbContext
{
    public PTSEventsContext(DbContextOptions<PTSEventsContext> options)
        : base(options)
    {
    }

    public DbSet<PTSEvent> PTSEventItems { get; set; } = null!;

    public DbSet<Participant> Participants { get; set; } = null!;
}