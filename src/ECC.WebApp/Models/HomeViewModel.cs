using ECC.Data;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class HomeViewModel
    {
        public List<Bed> Beds { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
