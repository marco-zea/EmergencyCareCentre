using ECC.Data;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class PatientViewModel
    {
        public Patient Patient { get; set; }
        public List<Comment> Comments { get; set; }        
    }
}
