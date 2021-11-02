using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Events.webui.Models
{
    public class CreateEventModel
    {

        public int? Id { get; set; }
        
        

        [Required(ErrorMessage="Organizasyon adı zorunlu bir alan.")] 
        public string Name { get; set; }
        
        
        [Required(ErrorMessage="Organizasyon Fotoğrafı zorunlu bir alan.")] 
        public string Image { get; set; }
        

        
        [Required(ErrorMessage="Url adı zorunlu bir alan.")] 
        public string Url { get; set; }

        [Required(ErrorMessage="Tür zorunlu bir alan.")] 
        public int GenresId { get; set; }
        
        [Required(ErrorMessage="Mekan zorunlu bir alan.")] 
        public int VenueId { get; set; }

        [Required(ErrorMessage="Şehir zorunlu bir alan.")] 
        public int CitiesId { get; set; }

        [Required(ErrorMessage="Tarih adı zorunlu bir alan.")] 
        public int DateId { get; set; }
        
        

    }
}