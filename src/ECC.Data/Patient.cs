using System.ComponentModel.DataAnnotations;
using System;

namespace ECC.Data
{
    public class Patient
    {
        [StringLength(7)]
        public string Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public DateTime DateOfBirth  { get; set; }       
    }
}