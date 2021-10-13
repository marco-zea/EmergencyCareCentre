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
                BedDetails = new List<BedDetails>(),
                UsedBeds = beds.Count(b => b.State == "In use"),
                FreeBeds = beds.Count(b => b.State == "Free"),
                TotalAdmissionsToday = comments.Count(c => c.IsAdmission && c.LastUpdated.Date == DateTime.Today),
            };

            foreach (var bed in beds)
            {
                var lastBedAddmission = comments.LastOrDefault(c => c.Bed?.Id == bed.Id && c.IsAdmission);
                var lastBedComment = comments.LastOrDefault(c => c.Bed?.Id == bed.Id && !c.IsAdmission);

                var patientId = lastBedAddmission != null ? lastBedAddmission?.Patient?.Id : lastBedComment?.Patient?.Id;
                var patientName = lastBedAddmission != null ? lastBedAddmission?.Patient?.FirstName + " " + lastBedAddmission?.Patient?.LastName : lastBedComment?.Patient?.FirstName + " " + lastBedComment?.Patient?.LastName;
                var patientDOB = lastBedAddmission != null ? lastBedAddmission?.Patient?.DateOfBirth.ToString("dd-MM-yyyy") : lastBedComment?.Patient?.DateOfBirth.ToString("dd-MM-yyyy");                
                var staff = lastBedComment != null ? lastBedComment?.Staff : lastBedAddmission?.Staff;

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
                    Staff = staff != null ? staff : string.Empty
                });
            }

            return View(viewModel);
        }

        [HttpGet()]        
        public async Task<IActionResult> Admit(int id)
        {
            var client = _clientFactory.CreateClient();
            var bed = new Bed();            

            //Bed
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/beds/" + id);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                bed = JsonConvert.DeserializeObject<Bed>(content);
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            var rand = new Random();

            var admitViewModel = new AdmitViewModel
            {
                BedId = bed.Id,
                PatientId = rand.Next(0000000, 9999999).ToString("0000000"),
                DateOfBirth = new DateTime(2000,01,01)
            };

            return View(admitViewModel);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Admit(int id, [Bind("BedId,PatientId,FirstName,LastName,DateOfBirth,Body,Staff")] AdmitViewModel admitViewModel)
        {
            if (id != admitViewModel.BedId) return NotFound();

            var comment = new Comment
            {
                Bed = new Bed { Id = id, State = "In use" },
                Patient = new Patient { 
                    Id = admitViewModel.PatientId, 
                    FirstName = admitViewModel.FirstName, 
                    LastName = admitViewModel.LastName, 
                    DateOfBirth = admitViewModel.DateOfBirth
                },
                Body = admitViewModel.Body,
                Staff = admitViewModel.Staff,
                LastUpdated = DateTime.Now,
                IsAdmission = true
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
        public async Task<IActionResult> Comment(string id)
        {
           var client = _clientFactory.CreateClient();
            var bed = new Bed();
            var patient = new Patient();

            //Bed
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/beds/" + id.Split("-")[0]);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                bed = JsonConvert.DeserializeObject<Bed>(responseContent);
                bed.State = "In use";
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            //Patient
            request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/patients/" + id.Split("-")[1]);
            response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                patient = JsonConvert.DeserializeObject<Patient>(responseContent);
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            var comment = new Comment
            {
                Bed = bed,
                Patient = patient,
                Body = "Adding comment",
                Staff = "Nurse",
                LastUpdated = DateTime.Now
            };

            var payload = JsonConvert.SerializeObject(comment);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            response = await client.PostAsync("https://localhost:5001/comments", content);
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
        public async Task<IActionResult> Discharge(string id)
        {
            var client = _clientFactory.CreateClient();
            var bed = new Bed();
            var patient = new Patient();

            //Bed
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/beds/" + id.Split("-")[0]);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                bed = JsonConvert.DeserializeObject<Bed>(responseContent);
                bed.State = "Free";
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            //Patient
            request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/patients/" + id.Split("-")[1]);
            response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                patient = JsonConvert.DeserializeObject<Patient>(responseContent);
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            var comment = new Comment
            {
                Bed = bed,
                Patient = patient,
                Body = "Discharge",
                Staff = "Doctor",
                LastUpdated = DateTime.Now
            };

            var payload = JsonConvert.SerializeObject(comment);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            response = await client.PostAsync("https://localhost:5001/comments", content);

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

            //Patient
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
