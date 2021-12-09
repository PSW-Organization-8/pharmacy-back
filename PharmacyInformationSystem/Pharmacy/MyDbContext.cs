﻿using Microsoft.EntityFrameworkCore;
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

        public MyDbContext()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
<<<<<<< Updated upstream
            String connectionString = "Server=localhost; Port =5432; Database=Pharmacy; User Id=postgres; Password =admin;";
=======
            String server = Environment.GetEnvironmentVariable("SERVER") ?? "localhost";
            String port = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
            String databaseName = Environment.GetEnvironmentVariable("DB_NAME") ?? "Pharmacy";
            String username = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
            String password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "admin";



            String connectionString = $"Server={server}; Port ={port}; Database ={databaseName}; User Id = {username}; Password ={password};";
            Console.WriteLine("###############################################################################");
            Console.WriteLine(connectionString);
            Console.WriteLine("###############################################################################");
>>>>>>> Stashed changes
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

        }

    }
}
