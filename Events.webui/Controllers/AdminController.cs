using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.webui.Context;
using Events.webui.Models;
using Events.webui.TicketContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Events.webui.Controllers
{
    public class AdminController:Controller
    {
        
        TicketDbContext context = new TicketDbContext();
        public void CreateMessage(string message, string type)
        {
            var msg = new AlertMessage()
            {
                Message = message,
                AlertType = type,
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
        }
        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult EventList()
        {
            var model = context.Events.Select(i => new EventModel()
            {
                EventId = i.Id,
                EventName = i.Name,
                EventImage = i.Name,
                EventDates = i.Date.Name,
                EventVenue = i.Venue.Name,
                VenueImage = i.Venue.Image,
                EventGenre = i.Genres.Name,
                EventCity = i.Cities.Name,
                ArtistName = i.Artists.Select(a => new ArtistModel()
                {
                    Name = a.Name,
                }).ToList()

            }).ToList();


            return View(model);
        }
   
        public IActionResult EventCreate()
        {
            ViewBag.SelectedGenre = new SelectList(context.Genres,"Id","Name");
            ViewBag.SelectedEvent = new SelectList(context.Events,"Id","Name");
            ViewBag.SelectedVenue = new SelectList(context.Venues,"Id","Name");
            ViewBag.SelectedCity = new SelectList(context.Cities,"Id","Name");
            return View();
        }
       
        [HttpPost]
        public IActionResult EventCreate(CreateEventModel model)
        {
            if(!ModelState.IsValid)
            {
                CreateMessage("Lütfen tüm alanları doldurmuş olduğunuza emin olun", "danger");
                return View(model);
            }
            
            var entity = new Events.webui.TicketContext.Event()
            {
                Name = model.Name,
                Image = model.Image,
                Url = model.Url,
                VenueId = model.VenueId,
                CitiesId = model.CitiesId,
                GenresId = model.GenresId,
                DateId = model.DateId
            };           
            context.Events.Add(entity);
            context.SaveChanges(); 

            CreateMessage("Bilgiler başarıyla eklendi.","success");

            return RedirectToAction("EventList");
        }

        public IActionResult EventDelete(int EventId)
        {
            var entity = context.Events.Find(EventId);
            if(entity!=null)
            {
                context.Remove(entity);
                context.SaveChanges();
            }
            CreateMessage("Bilgiler başarıyla silindi.","success");
            return RedirectToAction("EventList");

        }
       
        [HttpGet]
        public IActionResult EventEdit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var model = context.Events.Find((int)id);
            var entity = new CreateEventModel()
            {
                Id = model.Id,
                Name = model.Name,
                Url = model.Url,
                Image = model.Image,
            };
            ViewBag.SelectedGenre = new SelectList(context.Genres,"Id","Name");
            ViewBag.SelectedEvent = new SelectList(context.Events,"Id","Name");
            ViewBag.SelectedVenue = new SelectList(context.Venues,"Id","Name");
            ViewBag.SelectedCity = new SelectList(context.Cities,"Id","Name");
            return View(entity);
        }
        [HttpPost]
        public IActionResult EventEdit(CreateEventModel model)
        {
           
               if(!ModelState.IsValid)
               {
                   return View(model);
               }
               var events = context.Events.Find(model.Id);
                events.Name = model.Name;
                events.Image = model.Image;
                events.VenueId = model.VenueId;
                events.GenresId = model.GenresId;
                events.DateId = model.DateId;
                events.CitiesId = model.CitiesId;
                context.Update(events);
                context.SaveChanges();

            return RedirectToAction("EventList");

        }

        public IActionResult ArtistList()
        {
            var context = new TicketDbContext();
            var artist = context.Artists.Select(i => new ArtistModel()
            {
                Id = i.Id,
                Name = i.Name,
                Image = i.Image,
                Country = i.Country,
                Genres = i.Genres.Name
            }).ToList();
            
            return View(artist);
        }
        
        
        [HttpGet]
        public IActionResult ArtistCreate()
        {
            var context = new TicketDbContext();
            ViewBag.SelectGenres = new SelectList(context.Genres,"Id","Name");
            ViewBag.SelectEvent = new SelectList(context.Events,"Id","Name");
            return View();
        }
       
        [HttpPost]
        public IActionResult ArtistCreate(ArtistModel model)
        {
            var context = new TicketDbContext();
            if(!ModelState.IsValid)
            {
                CreateMessage("Alanları kontrol ediniz","danger");
                return View(model);
            }
            var entity = new Events.webui.TicketContext.Artist()
            {
                Name = model.Name,
                Country = model.Country,
                Image = model.Image,
                GenresId = model.GenresId,
                EventId = model.EventId
            };
            context.Artists.Add(entity);
            context.SaveChanges();
            CreateMessage("Bilgiler başarıyla eklendi.","success");
            return RedirectToAction("ArtistList");
        }

        [HttpGet]
        public IActionResult ArtistEdit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var artist = context.Artists.Find((int)id);
            var model = new ArtistModel()
            {
                Id = artist.Id,
                Name = artist.Name,
                Image = artist.Image,
                Country = artist.Country,
                Url = artist.Url
            };
            ViewBag.SelectedGenres = new SelectList(context.Genres,"Id","Name");
            ViewBag.SelectedEvent = new SelectList(context.Events,"Id","Name");
            return View(model);
        }

        [HttpPost]
        public IActionResult ArtistEdit(ArtistModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var artist = context.Artists.Find(model.Id);
            artist.Name = model.Name;
            artist.Country = model.Country;
            artist.Image = model.Image;
            artist.GenresId = model.GenresId;
            artist.EventId = model.EventId;
            artist.Url = model.Url;
            context.SaveChanges();
            return RedirectToAction("ArtistList");
        } 
       
       public IActionResult ArtistDelete(int artistId)
       {
           var DeletedArtist = context.Artists.Find(artistId);
           if(DeletedArtist != null)
           {
               context.Remove(DeletedArtist);
               context.SaveChanges();
           }
           CreateMessage("Bilgiler başarıyla silindi","success");
           return RedirectToAction("ArtistList");
       }
       
        public IActionResult VenueList()
        {
            var model = context.Venues.Include(i => i.Events).ToList();
            return View(model);

        }
        public IActionResult VenueCreate()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult VenueCreate(CreateVenueModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var entity = new  Events.webui.TicketContext.Venue()
            {
                Name = model.Name,
                Image = model.Image,
                Address = model.Address,
                Url = model.Url
            };
            context.Venues.Add(entity);
            context.SaveChanges();
            CreateMessage("Bilgiler başarıyla eklendi.","success");
            return RedirectToAction("VenueList");

        }

        public IActionResult VenueDelete(int venutId)
        {
            var deletedVenue = context.Venues.Find(venutId);
            if(deletedVenue != null)
            {
                context.Remove(deletedVenue);
                context.SaveChanges();
            }
            CreateMessage("Bilgiler başarıyla silindi.","success");
            return RedirectToAction("VenueList");
        }

        [HttpGet]
        public IActionResult VenueEdit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var venueEdit = context.Venues.Find((int)id);
            var model = new VenueModel()
            {
                Id = venueEdit.Id,
                Name = venueEdit.Name,
                Url = venueEdit.Url,
                Image = venueEdit.Image,
                Address = venueEdit.Address,
            };
            ViewBag.SelectedEvent = new SelectList(context.Events,"Id","Name");
            return View(model);
        }

        [HttpPost]
        public IActionResult VenueEdit(VenueModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var venue = context.Venues.Find(model.Id);
            venue.Name = model.Name;
            venue.Image = model.Image;
            venue.Address = model.Address;     
                   
            context.SaveChanges();
            return RedirectToAction("VenueList");
        }

























        
   
    
    }
}