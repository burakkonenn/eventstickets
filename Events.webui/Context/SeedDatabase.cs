using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.webui.TicketContext;
using Microsoft.EntityFrameworkCore;

namespace Events.webui.Context
{
    public class SeedDatabase
    {
        public static void Seed()
        {
            var context = new TicketDbContext();

            if(context.Database.GetPendingMigrations().Count() == 0)
            {
              
               
                if(context.Cities.Count() == 0 )
                {
                    context.Cities.AddRange(Cities);
                }
                if(context.Dates.Count() == 0 )
                {
                    context.Dates.AddRange(Dates);
                }
                if(context.Genres.Count() == 0 )
                {
                    context.Genres.AddRange(Genres);
                }
                if(context.Venues.Count() == 0 )
                {
                    context.Venues.AddRange(Venues);
                }
            }
            context.SaveChanges();
        }


        private static City[] Cities = {
            new City(){Id=1, Name="İstanbul", Url="istanbul"},
            new City(){Id=2, Name="İzmir", Url="izmir"},
            new City(){Id=3, Name="Ankara", Url="ankara"},
            new City(){Id=4, Name="Eskişehir", Url="eskisehir"},
            new City(){Id=5, Name="Antalya", Url="antalya"}
        };
        private static Genre[] Genres = {
            new Genre(){Id=1, Name="Techno", Url="techno"},
            new Genre(){Id=2, Name="Tech House", Url="tech-house"},
            new Genre(){Id=3, Name="Melodic House", Url="melodic-house"},
            new Genre(){Id=4, Name="Hard Techno", Url="hard-techno"},
            new Genre(){Id=5, Name="Acid Techno", Url="acid-techno"},
        };
        private static Venue[] Venues = {
            new Venue(){Id=1, Name="Klein", Url="klein", Address="İstanbul / Maslak", Image="1.jpg"},
            new Venue(){Id=2, Name="Kafes", Url="kafes", Address="İstanbul / Kilyos", Image="2.jpg"},
            new Venue(){Id=3, Name="Module", Url="module", Address="İstanbul / Maslak", Image="3.jpg"},
            new Venue(){Id=4, Name="Zorlu PSM", Url="zorlu-psm", Address="İstanbul / Mecidiyeköy", Image="4.jpg"},
            new Venue(){Id=5, Name="Suma Han", Url="suma-han", Address="İstanbul / Kilyos", Image="5.jpg"},
        };
        private static Date[] Dates = {
            new Date(){Id=1, Name="Pazartesi", Url="pazartesi", Time="01.10.2021"},
            new Date(){Id=2, Name="Salı", Url="salı", Time="02.10.2021"},
            new Date(){Id=3, Name="Çarşamba", Url="carsamba", Time="03.10.2021"},
            new Date(){Id=4, Name="Perşembe", Url="persembe", Time="04.10.2021"},
            new Date(){Id=5, Name="Cuma", Url="cuma", Time="05.10.2021"},
            new Date(){Id=6, Name="Cumartesi", Url="cumartesi", Time="06.10.2021"},
            new Date(){Id=7, Name="Pazar", Url="pazar", Time="07.10.2021"},
        };
      
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }
}