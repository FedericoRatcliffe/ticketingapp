using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.Domain.Entities;

namespace TicketingApp.Persistence.DbContexts
{
    public class TicketingDbContext : DbContext
    {

        public TicketingDbContext(DbContextOptions<TicketingDbContext> options): base(options){
        }

        //public DbSet<Event> Events { get; set; }
        //public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuraciones con Fluent API si querés (puede venir después)
        }


    }


}
