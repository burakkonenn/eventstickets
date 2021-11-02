using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Events.webui.Models
{
    public class CreateVenueModel
    {
        [Required(ErrorMessage="İsim zorunlu bir alan.")] 
        public string Name { get; set; }

        [Required(ErrorMessage="Fotoğraf zorunlu bir alan.")] 
        public string Image { get; set; }

        [Required(ErrorMessage="Adres zorunlu bir alan.")] 
        public string Address { get; set; }

        [Required(ErrorMessage="Url zorunlu bir alan.")] 
        public string Url { get; set; }
        
        
        
        
        
    }
}