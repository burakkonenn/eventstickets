using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.webui.Models;

namespace Events.webui.TicketContext
{
    public class CartItems
    {
        
        public int Id { get; set; }

        public int EventId { get; set; }
        
        public Event Event { get; set; }
        
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int Quantity { get; set; }
    }
}