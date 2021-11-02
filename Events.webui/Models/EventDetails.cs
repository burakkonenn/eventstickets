using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.webui.Context;
using Events.webui.TicketContext;

namespace Events.webui.Models
{
    public class EventDetails
    {

        public List<City> Cities { get; set; }
        public List<Events.webui.TicketContext.Event> Event { get; set; }
        public List<Date> Datess { get; set; }
        public List<Date> Date { get; set; }
        public List<Venue> Venue { get; set; }
        public Venue Venues { get; set; }
        public List<Events.webui.TicketContext.Event> Events { get; set; }
        public List<Artist> Artist  { get; set; }
        public int EventCount { get; set; }
        
        
        
        
        
    }
}