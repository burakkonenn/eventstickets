using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.webui.Context;
using Events.webui.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using  Events.webui.TicketContext;
using AutoMapper;

namespace Events.webui.Controllers
{
    public class HomeController:Controller
    {
    public IActionResult Index(string name)
       {
           
           var context = new TicketDbContext();
                       
            var model = context.Cities.Select(i => new CityModel()
            {
                CityName = i.Name
                
            }).ToList();

            var Dates = context.Dates.Select(i => new DateModel()
            {
              DateName = i.Name,
              Time = i.Time
            }).ToList();

            ViewBag.Model = model;
            ViewBag.Dates = Dates;

            // var EventDetails = context.Events
            //                                  .Include(i => i.Date).Where(i => i.Date.Name==name).ToList();
                                

            // var entity = new EventDetails()
            // {
                
            //     Event = EventDetails,
            // };
        
            return View();
       }

    public IActionResult EventDetail(string Url)
       {
          // var context = new TicketDbContext();
          // if(Url == null)
          // {
          //   return NotFound();
          // }

          // var model = context.Events.Where(i => i.Url == Url)
          //                           .Include(i => i.Artists)
          //                           .Include(i => i.Date)
          //                           .Include(i => i.Venue).FirstOrDefault();
          // var Event = new EventDetailsModel()
          // {
          //   Events = model,
          // };
           return View();
       }


    public IActionResult Search(string q)
      {
          TicketDbContext context = new TicketDbContext();
          if(q == null)
          {
              return NotFound();
          }
          var SearchValue = context.Events.Include(i => i.Date).Include(i => i.Venue).Include(i => i.Cities).Include(i => i.Artists).ToList()
                                          .Where(i => i.Name.ToLower().Contains(q.ToLower())).ToList();

          var searchModel = new EventSearchModel()
          {
            Events = SearchValue
          };                                      
                                        
        return View(searchModel);
      }
   
    public IActionResult Events()
      {
            Events.webui.TicketContext.Event evt = new TicketContext.Event();
                      
           
            var context = new TicketDbContext();
                       
            var model = context.Cities.Select(i => new CityModel(){CityName=i.Name}).ToList();
            var Dates = context.Dates.Select(i => new DateModel(){DateName=i.Name}).ToList();
            ViewBag.Model = model;
            ViewBag.Dates = Dates;
      
            var Genre = context.Genres.ToList();
            ViewBag.Genres = Genre;

            var EvtCount = context.Events.Count();
            var EventsList = context.Events.Include(i => i.Venue).Include(i =>i.Date).ToList();
            
            var entity = new EventDetails()
            {
                EventCount = EvtCount,
                Events = EventsList
            };
           
        
          return View(entity);
      }
    
    public IActionResult Venue()
    {
        var context = new TicketDbContext();
        var City = context.Cities.ToList();
        var Genres = context.Genres.ToList();
        var VenueCount = context.Venues.Count();
        var Venue = context.Venues.ToList();

        var model = new CityGenres()
        {
            City = City,
            Genres = Genres,
            AllVenue = VenueCount,
            Venues = Venue
        };
    
        return View(model);        
    }

    public IActionResult Artist()
    {
        var context = new TicketDbContext();
        var artist = context.Artists.ToList();
        var genrs = context.Genres.ToList();
        var ct = context.Cities.ToList();
        var count = context.Artists.Count();

        var model = new CityGenres()
        {
            Artists = artist,
            Genres = genrs,
            City = ct,
            ArtistCount = count
        };
        return View(model);
    }

    public IActionResult SearchVenue(string venue)
    {
        if(venue == null)
        {
            return NotFound();
        }
        var context = new TicketDbContext();
        var Venue = context.Venues.Where(i => i.Name.ToLower().Contains(venue.ToLower())).ToList();
        ViewBag.SearchVenue = Venue;

        return View();
    }
   
    public IActionResult searchartist(string artist)
    {   
        var context = new TicketDbContext();
        var model = context.Artists.Include(i => i.Genres).Where(i => i.Name.ToLower().Contains(artist.ToLower())).ToList();
        ViewBag.SearchArtist = model;    
     
        return View();
    }









    }
}