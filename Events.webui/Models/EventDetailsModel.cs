using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.webui.TicketContext;

namespace Events.webui.Models
{
    public class EventDetailsModel
    {
        public Artist Artist { get; set; }
        public Events.webui.TicketContext.Event Event { get; set; }
        public City City { get; set; }
        public Date Date { get; set; }
        public Venue Venue { get; set; }
        public Events.webui.TicketContext.Event Events { get; set; }
        
        
        
        
    }
}