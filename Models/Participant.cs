using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSEventsApi.Models
{
    public class Participant
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Company { get; set; }
        public string? CellPhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public bool AttendRemote { get; set; }

        //Foreign Key
        public long PTSEventId { get; set; }

        //Navigation Property
        public PTSEvent PTSEvent { get; set; } = null!;
        
    }
}