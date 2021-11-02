using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.webui.TicketContext;

namespace Events.webui.Models
{
    public class VenueModel
    {
        public Venue Venues { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Url { get; set; }
        public int EventId { get; set; }
        
                
        
    }
}