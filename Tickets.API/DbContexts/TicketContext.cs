using Microsoft.EntityFrameworkCore;
using Tickets.API.Entities;

namespace Tickets.API.DbContexts
{
    public class TicketContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; } = null!;

        public TicketContext(DbContextOptions<TicketContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket("a@a.com", "Alex", 4, 2)
                {
                    Id = 1
                },
               new Ticket("b@b.com", "Bob", 5, 3)
               {
                   Id = 2,
               },
               new Ticket("s@s.com", "Sarah", 2, 1)
               {
                   Id = 3,
               });
        }
    }
}
