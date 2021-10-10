using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace ECC.DataMigration
{ 
    public class Patient
    {
        [StringLength(7)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth  { get; set; }       
    }
}