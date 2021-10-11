using ECC.Data;
using System;
using System.Collections.Generic;
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

            var beds = new List<Bed>
            {
                new Bed { State = "In use" },
                new Bed { State = "Free" },
                new Bed { State = "Free" },
                new Bed { State = "Free" },
                new Bed { State = "In use" },
                new Bed { State = "In use" },
                new Bed { State = "Free" },
                new Bed { State = "Free" }
            };

            foreach (Bed bed in beds)
            {
                context.Beds.Update(bed);
            }

            var patients = new List<Patient>
            {
                new Patient { Id = "0083524", FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1980, 01, 01) },
                new Patient { Id = "0083525", FirstName = "Lorna", LastName = "Smith", DateOfBirth = new DateTime(1995, 03, 15) },
                new Patient { Id = "0083526", FirstName = "Diana", LastName = "May", DateOfBirth = new DateTime(1972, 11, 23) },
                new Patient { Id = "0083527", FirstName = "Fred", LastName = "Smith", DateOfBirth = new DateTime(1952, 10, 21) }
            };

            foreach (Patient patient in patients)
            {
                context.Patients.Add(patient);
            }

            context.SaveChanges();
        }
    }
}
