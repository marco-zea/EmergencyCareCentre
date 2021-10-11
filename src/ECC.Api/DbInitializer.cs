using ECC.Data;
using System;
using System.Linq;

namespace ECC.WebApi
{
    public class DbInitializer
    {
        public static void Initialize(EccDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Beds.
            if (context.Beds.Any())
            {
                return;   // DB has been seeded
            }

            context.Beds.Add(new Bed {State = "In use" });
            context.Beds.Add(new Bed {State = "Free" });
            context.Beds.Add(new Bed {State = "Free" });
            context.Beds.Add(new Bed {State = "Free" });
            context.Beds.Add(new Bed {State = "In use" });
            context.Beds.Add(new Bed {State = "In use" });
            context.Beds.Add(new Bed {State = "In use" });
            context.Beds.Add(new Bed {State = "In use" });

            context.Patients.Add(new Patient { Id = "0083524", FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1980, 01, 01) });
            context.Patients.Add(new Patient { Id = "0083525", FirstName = "Lorna", LastName = "Smith", DateOfBirth = new DateTime(1995, 03, 15) });
            context.Patients.Add(new Patient { Id = "0083526", FirstName = "Diana", LastName = "May", DateOfBirth = new DateTime(1972, 11, 23) });
            
            context.SaveChanges();
        }
    }
}
