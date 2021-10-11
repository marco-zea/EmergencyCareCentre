using ECC.Data;
using System;
using System.Net.Http;

namespace ECC.WebApp.Services
{
    public class EmergencyCareService
    {
        private readonly IHttpClientFactory _clientFactory;

        public EmergencyCareService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public Comment InitialComment(int bedId, string patientId )
        {
            //TODO: call web api
            return new Comment { Bed = { Id = bedId }, Patient = { Id = patientId }, Body = "Admission state", LastUpdated = DateTime.UtcNow };
        }
        public Comment LastComment(int bedId, string patientId)
        {
            //TODO: call web api
            return new Comment { Bed = { Id = bedId }, Patient = { Id = patientId }, Body = "Added Comment", LastUpdated = DateTime.UtcNow };
        }

        public int GetUsedBeds()
        {
            //TODO: call web api
            return 3;
        }

        public int GetFreeBeds()
        {
            //TODO: call web api
            return 4;
        }

        public int GetTotalAdmittedToday()
        {
            return 22;
        }
    }
}
