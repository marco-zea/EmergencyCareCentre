using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class AdmitViewModel
    {
        public int BedId { get; set; }

        [Display(Name = "Patient Id")]
        public string PatientId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Comment")]
        public string Body { get; set; }
        [Display(Name = "Nurse")]
        public string Staff { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
