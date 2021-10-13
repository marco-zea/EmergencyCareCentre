using ECC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var beds = new List<Bed>();
            var comments = new List<Comment>();

            //Beds
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/beds");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                beds = JsonConvert.DeserializeObject<IList<Bed>>(content).ToList();
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            //Comments
            request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/comments");
            response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                comments = JsonConvert.DeserializeObject<IList<Comment>>(content).ToList();
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            var viewModel = new HomeViewModel
            {
                BedDetails = new List<BedDetails>()
            };

            foreach (var bed in beds)
            {
                var lastBedAddmission = comments.LastOrDefault(c => c.Bed?.Id == bed.Id && c.Body == "Admission reason");
                var lastBedComment = comments.LastOrDefault(c => c.Bed?.Id == bed.Id && c.Body == "Adding a comment");

                var patientId = lastBedAddmission != null ? lastBedAddmission?.Patient?.Id : lastBedComment?.Patient?.Id;
                var patientName = lastBedAddmission != null ? lastBedAddmission?.Patient?.FirstName + " " + lastBedAddmission?.Patient?.LastName : lastBedComment?.Patient?.FirstName + " " + lastBedComment?.Patient?.LastName;
                var patientDOB = lastBedAddmission != null ? lastBedAddmission?.Patient?.DateOfBirth.ToString("dd-MM-yyyy") : lastBedComment?.Patient?.DateOfBirth.ToString("dd-MM-yyyy");                

                viewModel.BedDetails.Add(new BedDetails
                {
                    BedId = bed.Id,
                    State = bed.State,
                    PatientId = patientId != null ? patientId : string.Empty,
                    PatientName = patientName != null ? patientName : string.Empty,
                    DateOfBirth = patientDOB != null ? patientDOB : string.Empty,
                    AdmissionReason = lastBedAddmission != null ? lastBedAddmission?.Body : string.Empty,
                    LastComment = lastBedComment != null ? lastBedComment?.Body : string.Empty,
                    LastUpdate = lastBedComment != null ? lastBedComment?.LastUpdated.ToString("dd-MM-yyyy hh:mm:ss") : string.Empty,
                    Staff = lastBedComment != null ? lastBedComment?.Staff : string.Empty
                });
            }

            return View(viewModel);
        }

        [HttpGet()]        
        public async Task<IActionResult> Admit(int? id)
        {                        
            var comment = new Comment
            {
                Bed = new Bed { Id = (int)id, State = "In use" },
                Patient = new Patient { Id = "0083527", FirstName = "Fred", LastName = "Smith", DateOfBirth = new DateTime(1952, 10, 21) },
                Body = "Admission reason",
                Staff = "Mary P.",
                LastUpdated = DateTime.UtcNow                
            };
            
            var payload =  JsonConvert.SerializeObject(comment);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.PostAsync("https://localhost:5001/comments", content);

            if (response.IsSuccessStatusCode)
            {                           
                return RedirectToAction("Index");
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }            
        }


        [HttpGet()]
        public async Task<IActionResult> Comment(int? id)
        {
            var comment = new Comment
            {
                Bed = new Bed { Id = (int)id, State = "In use" },
                Patient = new Patient { Id = "0083527", FirstName = "Fred", LastName = "Smith", DateOfBirth = new DateTime(1952, 10, 21) },
                Body = "Adding a comment",
                Staff = "Mary P.",
                LastUpdated = DateTime.UtcNow
            };

            var payload = JsonConvert.SerializeObject(comment);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.PostAsync("https://localhost:5001/comments", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

        }

        [HttpGet()]
        public async Task<IActionResult> Discharge(int? id)
        {
            var comment = new Comment
            {
                Bed = new Bed { Id = (int)id, State = "Free" },
                Patient = new Patient { Id = "0083527", FirstName = "Fred", LastName = "Smith", DateOfBirth = new DateTime(1952, 10, 21) },
                Body = "Discharge",
                Staff = "Mary P.",
                LastUpdated = DateTime.UtcNow
            };

            var payload = JsonConvert.SerializeObject(comment);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.PostAsync("https://localhost:5001/comments", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet()]
        public async Task<IActionResult> Patient(string id)
        {
            var client = _clientFactory.CreateClient();
            var patient = new Patient();
            var comments = new List<Comment>();

            //Beds
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/patients/" + id);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                patient = JsonConvert.DeserializeObject<Patient>(content);
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            //Comments
            request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/comments");
            response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                comments = JsonConvert.DeserializeObject<IList<Comment>>(content).ToList();
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            var patientComments = comments.FindAll(c => c.Patient?.Id == id).ToList();
            var patientVieModel = new PatientViewModel
            {
                Patient = patient,
                Comments = patientComments
            };

            return View(patientVieModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
