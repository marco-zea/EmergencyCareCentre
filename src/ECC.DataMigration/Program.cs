using System;
using ECC.DataMigration; 

namespace EmergencyCareCentre
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EccDbContext())
            {
                var bed = new Bed {
                    Id = 1,
                    State = "In use"
                };
                context.Add(bed);
                context.SaveChanges();
            }       
        }
    }
}
