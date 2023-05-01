using Microsoft.EntityFrameworkCore;

namespace PTSEventsApi.Models;

public class PTSEventsContext : DbContext
{
    public PTSEventsContext(DbContextOptions<PTSEventsContext> options)
        : base(options)
    {
    }

    public DbSet<PTSEvent> PTSEventItems { get; set; } = null!;

    public DbSet<PTSEvent> Participants { get; set; } = null!;
}