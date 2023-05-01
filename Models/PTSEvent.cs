namespace PTSEventsApi.Models;

public class PTSEvent
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}