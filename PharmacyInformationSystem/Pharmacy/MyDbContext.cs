using Microsoft.EntityFrameworkCore;
using PharmacyClassLib.Model;
using PharmacyClassLib.Model.Enums;
using PharmacyClassLib.Model.Relations;
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
            modelBuilder.Entity<Pharmacy>().HasData(
                new Pharmacy(1, "Janković", "Novi Sad", "Rumenačka", "15"),
                new Pharmacy(2, "Janković", "Novi Sad", "Bulevar oslobođenja", "135"),
                new Pharmacy(3, "Janković", "Beograd", "Olge Jovanović", "18a")
                );

            modelBuilder.Entity<Objection>().HasData(
                new Objection(1, 0, "Ne valja nista", "Bolnica1")
                );

            modelBuilder.Entity<Response>().HasData(
                new Response(1, 0, "Kleveta", "Bolnica1")
                );

            modelBuilder.Entity<RegisteredHospital>().HasData(
                new RegisteredHospital("Bolnica1", "http:localhost:7313", "fds15d4fs6")
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
                new PharmacyOffer(1, 1, 1, 15.5, false, "Bolnica1", new DateTime(2021, 5, 1, 8, 30, 52)),
                new PharmacyOffer(2, 2, 2, 40.0, false, "Bolnica1", new DateTime(2021, 10, 12, 9, 28, 13))
                );

            modelBuilder.Entity<PharmacyOfferComponent>().HasData(
                new PharmacyOfferComponent(1, 1, 1, 30),
                new PharmacyOfferComponent(2, 1, 2, 18),
                new PharmacyOfferComponent(3, 2, 3, 35),
                new PharmacyOfferComponent(4, 2, 2, 31),
                new PharmacyOfferComponent(5, 2, 1, 45)
                );

        }

    }
}
