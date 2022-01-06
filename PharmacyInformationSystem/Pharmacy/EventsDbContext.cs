using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyClassLib.Model;
using PharmacyClassLib.Model.Enums;

namespace PharmacyClassLib
{
    public class EventsDbContext : DbContext
    {
        public DbSet<Event> Events{ get; set; }

        public EventsDbContext()
        {

        }

        public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String server = Environment.GetEnvironmentVariable("SERVER") ?? "localhost";
            String port = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
            String databaseName = Environment.GetEnvironmentVariable("DB_NAME_EVENTS") ?? "PharmacyEvents";
            String username = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
            String password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "2331";

            String connectionString = $"Server={server}; Port ={port}; Database ={databaseName}; User Id = {username}; Password ={password};";
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Event event1 = new Event(1, "username1", ApplicationName.PharmacyApp, EventClass.CancelForm);
            Event event2 = new Event(2, "username2", ApplicationName.PharmacyApp, EventClass.EnterForm);
            Event event3 = new Event(3, "username1", ApplicationName.PharmacyApp, EventClass.MedicationPreview);
            event3.OptionalEventNumInfo = 1;

            modelBuilder.Entity<Event>().HasData(
                event1,
                event2,
                event3
            );

        }
    }

}
