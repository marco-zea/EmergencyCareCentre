using Microsoft.EntityFrameworkCore;
namespace ECC.DataMigration
{
    public class EccDbContext : DbContext
    {
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\MSSQLSERVER;Database=ecc;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}