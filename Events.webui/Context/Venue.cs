using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Events.webui.TicketContext
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Url { get; set; }
        public List<Event> Events { get; set; }
        
        
        
    }
}