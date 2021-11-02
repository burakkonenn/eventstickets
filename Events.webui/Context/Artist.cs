using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Events.webui.Models;

namespace Events.webui.TicketContext
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string Image { get; set; }

        
        public int GenresId { get; set; }

        public Genre Genres { get; set; }

        public string Url { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }
        

        
    }
}