using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.webui.TicketContext;
using Microsoft.EntityFrameworkCore;

namespace Events.webui.Context
{
    public class TicketDbContext: DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TicketDatabase");
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
        

      
    }
}