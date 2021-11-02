using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.webui.TicketContext;

namespace Events.webui.Models
{
    public class ArtistModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }
        public string Genres { get; set; }
        public int GenresId { get; set; }
        public int EventId { get; set; }
        public string Url { get; set; }
        
   
    }
}