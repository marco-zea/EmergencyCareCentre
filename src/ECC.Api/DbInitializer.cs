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

            context.Comments.Update(new Comment
            {
                Bed = beds.Single(b => b.Id == 1),
                Patient = patients.Single(p => p.Id == "0083524"),
                Body = "Nausea, dizziness",
                LastUpdated = new DateTime(2020, 02, 02, 09, 05, 23),
                Staff = "Mary P.",
                IsAdmission = true
            });

            context.Comments.Update(new Comment
            {
                Bed = beds.Single(b => b.Id == 1),
                Patient = patients.Single(p => p.Id == "0083524"),
                Body = "Blood pressure checked",
                LastUpdated = new DateTime(2020, 02, 02, 10, 25, 22),
                Staff = "Mary P."
            });

            context.Comments.Update(new Comment
            {
                Bed = beds.Single(b => b.Id == 5),
                Patient = patients.Single(p => p.Id == "0083525"),
                Body = "Broken leg",
                LastUpdated = new DateTime(2020, 02, 02, 04, 10, 23),
                Staff = "Mary P.",
                IsAdmission = true
            });

            context.Comments.Update(new Comment
            {
                Bed = beds.Single(b => b.Id == 5),
                Patient = patients.Single(p => p.Id == "0083525"),
                Body = "X-Ray waiting results",
                LastUpdated = new DateTime(2020, 02, 02, 07, 30, 25),
                Staff = "Mary P."
            });

            context.Comments.Update(new Comment
            {
                Bed = beds.Single(b => b.Id == 6),
                Patient = patients.Single(p => p.Id == "0083526"),
                Body = "High fever",
                LastUpdated = new DateTime(2020, 02, 02, 07, 15, 48),
                Staff = "Kelly A. ",
                IsAdmission = true
            });

            context.Comments.Update(new Comment
            {
                Bed = beds.Single(b => b.Id == 6),
                Patient = patients.Single(p => p.Id == "0083526"),
                Body = "Medication supplied",
                LastUpdated = new DateTime(2020, 02, 02, 09, 45, 25),
                Staff = "Kelly A. "
            });

            context.SaveChanges();
        }
    }
}
