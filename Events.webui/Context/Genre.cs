using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Events.webui.Models;

namespace Events.webui.TicketContext
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<Event> Events { get; set; }
        public List<Artist> Artists { get; set; }
        
        

    }
}