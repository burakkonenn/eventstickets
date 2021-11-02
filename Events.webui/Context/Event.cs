using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Events.webui.TicketContext
{
    
    public class Event
    {
        [Key]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        
        public int DateId { get; set; }
        public Date Date { get; set; }
        
        public List<Artist> Artists { get; set; }
        
        
        public int CitiesId { get; set; }
        public City Cities { get; set; }
        
        
        public int GenresId { get; set; }
        public Genre Genres { get; set; }
        
        
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        
        
        
    }
}