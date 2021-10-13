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
