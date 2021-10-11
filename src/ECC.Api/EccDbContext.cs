using Microsoft.EntityFrameworkCore;
using ECC.Data;
using System;

namespace ECC.WebApi
{ 
    public class EccDbContext : DbContext
    {
        public EccDbContext(DbContextOptions<EccDbContext> options) : base(options)
        {
        }

        public DbSet<Bed> Beds { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=AU-H1SNNF2\MSSQLLOCALDB;Database=EmergencyCare;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}