using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.webui.TicketContext;

namespace Events.webui.Models
{
    public class EventModel
    {
        public int? EventId { get; set; }
        public string EventName { get; set; }
        public string EventImage { get; set; }
        public string EventDates { get; set; }
        public string EventVenue { get; set; }
        public List<ArtistModel> ArtistName { get; set; }
        public string VenueImage { get; set; }
        public string EventGenre { get; set; }
        public string EventCity { get; set; }
        
        
        

    }
}