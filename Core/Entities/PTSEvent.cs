namespace PTSEventsApi.Core.Entities;

public class PTSEvent
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }



    //Navigation Property
    public List<Participant> Participants { get; set; } = new List<Participant>();
}