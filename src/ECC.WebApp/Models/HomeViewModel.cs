using System.Collections.Generic;

namespace WebApp.Models
{
    public class HomeViewModel
    {
        public int UsedBeds { get; set; }
        public int FreeBeds { get; set; }
        public int TotalAdmissionsToday { get; set; }

        public List<BedDetails> BedDetails { get; set; }        
    }

    public class BedDetails
    {
        public int BedId { get; set; }
        public string State { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set; }        
        public string DateOfBirth { get; set; }
        public string AdmissionReason { get; set; }
        public string LastComment { get; set; }
        public string LastUpdate { get; set; }
        public string Staff { get; set; }
    }

}
