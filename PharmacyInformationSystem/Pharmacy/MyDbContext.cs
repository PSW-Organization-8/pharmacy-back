using Microsoft.EntityFrameworkCore;
using PharmacyClassLib.Model;
using PharmacyClassLib.Model.Commercials;
using PharmacyClassLib.Model.Enums;
using PharmacyClassLib.Model.Relations;
using PharmacyClassLib.ModelConfiguration;
using System;
using System.Collections.Generic;

namespace PharmacyClassLib
{
    public class MyDbContext : DbContext
    {
        public DbSet<RegisteredHospital> RegistratedHospitals { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<MedicationIngredient> MedicationIngredients { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<InventoryLog> InventoryLogs { get; set; }
        public DbSet<Objection> Objections { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<PharmacyOffer> PharmacyOffers { get; set; }
        public DbSet<PharmacyOfferComponent> PharmacyOfferComponents { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<TenderMedication> TenderMedications { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<MedicationPromotion> MedicationPromotions { get; set; }
        
        

        public MyDbContext()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String server = Environment.GetEnvironmentVariable("SERVER") ?? "localhost";
            String port = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
            String databaseName = Environment.GetEnvironmentVariable("DB_NAME") ?? "Pharmacy";
            String username = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
            String password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "root";


            String connectionString = $"Server={server}; Port ={port}; Database ={databaseName}; User Id = {username}; Password ={password};";
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new MedicationPromotionConfiguration());


            modelBuilder.Entity<Pharmacy>().HasData(
                 new Pharmacy(1, "Janković", "Novi Sad", "Rumenačka", "15"),
                 new Pharmacy(2, "Janković", "Novi Sad", "Bulevar oslobođenja", "135"),
                 new Pharmacy(3, "Janković", "Beograd", "Olge Jovanović", "18a")
                 );

            modelBuilder.Entity<Notification>().HasData(
                new Notification(1, "Izvestaj", true, "Ovde ce da bude tekst nekog izvestaja", "MedicationSpecifiation.pdf")
                );

            modelBuilder.Entity<Objection>().HasData(
                new Objection(1, 0, "Ne valja nista", "Bolnica1")
                );

            modelBuilder.Entity<Response>().HasData(
                new Response(1, 0, "Kleveta", "Bolnica1")
                );

            modelBuilder.Entity<RegisteredHospital>().HasData(
                new RegisteredHospital("Bolnica1", "http:localhost:7313", "fds15d4fs6", "psworganisation8+Bolnica1@outlook.com")
                );


            modelBuilder.Entity<Medication>().HasData(
                new Medication(1, "Synthroid", "J&J", MedicineApprovalStatus.Accepted, 150, "Taken once per day", "None.", "None."),
                new Medication(2, "Ventolin", "Merck & Co. Inc.", MedicineApprovalStatus.Waiting, 200, "Taken twice per day", "None.", "Not advised for pregnant women."),
                new Medication(3, "Januvia", "Pfizer Inc.", MedicineApprovalStatus.Accepted, 750, "Taken once once every 5 hours", "None.", "Not advised for children.")
                );

            MedicationIngredient ingredient1 = new MedicationIngredient(1, "Vitamin C");
            MedicationIngredient ingredient2 = new MedicationIngredient(2, "Phosphorus");
            MedicationIngredient ingredient3 = new MedicationIngredient(3, "Calcium");

            modelBuilder.Entity<MedicationIngredient>().HasData(
                ingredient1,
                ingredient2,
                ingredient3
                );

            modelBuilder.Entity<IngredientInMedication>().HasData(
                new IngredientInMedication(1, 1, 1),
                new IngredientInMedication(2, 2, 2),
                new IngredientInMedication(3, 1, 2)
                );


            modelBuilder.Entity<InventoryLog>().HasData(
                new InventoryLog(1, 1, 1, 65),
                new InventoryLog(2, 1, 2, 85),
                new InventoryLog(3, 2, 1, 20),
                new InventoryLog(4, 2, 3, 120),
                new InventoryLog(5, 3, 1, 14)
                );

            modelBuilder.Entity<PharmacyOffer>().HasData(
                new PharmacyOffer(1, new DateTime(2021, 5, 1, 8, 30, 52), new List<PharmacyOfferComponent>()),
                new PharmacyOffer(2, new DateTime(2021, 10, 12, 9, 28, 13), new List<PharmacyOfferComponent>())
                );

            modelBuilder.Entity<PharmacyOfferComponent>().HasData(
                new PharmacyOfferComponent { Id = 1, Price = 100, Quantity = 10, MedicationId = 1, PharmacyOfferId = 1 },
                new PharmacyOfferComponent { Id = 2, Price = 1000, Quantity = 150, MedicationId = 2, PharmacyOfferId = 1 },
                new PharmacyOfferComponent { Id = 3, Price = 2000, Quantity = 150, MedicationId = 3, PharmacyOfferId = 1 },
                new PharmacyOfferComponent { Id = 4, Price = 1000, Quantity = 15, MedicationId = 2, PharmacyOfferId = 2 },
                new PharmacyOfferComponent { Id = 5, Price = 2000, Quantity = 2, MedicationId = 3, PharmacyOfferId = 2 }
                );

            modelBuilder.Entity<Tender>().HasData(
                new Tender { Id = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(50), Name = "Tender za Bolnicu zdravo", TenderMedications = new List<TenderMedication>(), HospitalName = "Bolnica1" },
                new Tender { Id = 2, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30), Name = "Tender za neku drugu Bolnicu", TenderMedications = new List<TenderMedication>(), HospitalName = "Bolnica1" }
                );
            modelBuilder.Entity<TenderMedication>().HasData(
                new TenderMedication { Id = 1, MedicationName = "Paracetamol", Quantity = 10, TenderId = 1 },
                new TenderMedication { Id = 2, MedicationName = "Vitamin C", Quantity = 10, TenderId = 1 },
                new TenderMedication { Id = 3, MedicationName = "Longacef", Quantity = 100, TenderId = 2 },
                new TenderMedication { Id = 4, MedicationName = "Zavoj", Quantity = 100, TenderId = 1 }
                );


        }



    }
}
