using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.webui.TicketContext;

namespace Events.webui.Models
{
    public class CityGenres
    {
        public List<City> City { get; set; }
        public List<Genre> Genres { get; set; }
        public int AllVenue { get; set; }
        public List<Venue> Venues { get; set; }
        public List<Artist> Artists { get; set; }
        public int ArtistCount { get; set; }
        
        
        
        
        
        
    }
}