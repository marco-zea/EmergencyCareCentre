using Microsoft.EntityFrameworkCore;
using ECC.Data;
using System;

namespace ECC.DataMigration
{
    public class EccDbContext : DbContext
    {
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=AU-H1SNNF2\MSSQLLOCALDB;Database=EmergencyCare;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Bed>().HasData(new Bed { Id=-1, State = "In use" });
            modelBuilder.Entity<Bed>().HasData(new Bed { Id = -1, State = "Free" });
            modelBuilder.Entity<Bed>().HasData(new Bed { Id = -1, State = "Free" });
            modelBuilder.Entity<Bed>().HasData(new Bed { Id = -1, State = "Free" });
            modelBuilder.Entity<Bed>().HasData(new Bed { Id = -1, State = "In use" });
            modelBuilder.Entity<Bed>().HasData(new Bed { Id = -1, State = "In use" });
            modelBuilder.Entity<Bed>().HasData(new Bed { Id = -1, State = "In use" });
            modelBuilder.Entity<Bed>().HasData(new Bed { Id = -1, State = "In use" });

            modelBuilder.Entity<Patient>().HasData(new Patient { Id = "0083524", FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1980, 01, 01) });
            modelBuilder.Entity<Patient>().HasData(new Patient { Id = "0083525", FirstName = "Lorna", LastName = "Smith", DateOfBirth = new DateTime(1995, 03, 15) });
            modelBuilder.Entity<Patient>().HasData(new Patient { Id = "0083526", FirstName = "Diana", LastName = "May", DateOfBirth = new DateTime(1972, 11, 23) });

        }
    }
}