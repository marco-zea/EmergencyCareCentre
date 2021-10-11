﻿using ECC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
            var viewModel = new HomeViewModel();

            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/beds");
            var client = _clientFactory.CreateClient();            
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var beds = JsonConvert.DeserializeObject<IList<Bed>>(content);
                viewModel.Beds = beds.ToList();
            }
            else
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            
            return View(viewModel);
        }

        [HttpGet()]        
        public async Task<IActionResult> Admit(int? id)
        {            
            var currentDateTime = DateTime.UtcNow;
            
            var payload = "{\"Bed\": {\"Id\":" + id + "}, \"Patient\": {\"Id\": \"0083527\"}, \"Body\": \"Admission state\", \"Staff\" : \"Mary P.\", \"LastUpdated\":" + currentDateTime.ToString() + "}";

            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5001/comments")
            {
                Content = new StringContent(payload, Encoding.UTF8, "application/json")
            };
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                //var content = await response.Content.ReadAsStringAsync();                
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
            var currentDateTime = DateTime.UtcNow;

            var payload = "{\"Bed\": {\"Id\":" + id + "}, \"Patient\": {\"Id\": \"0083527\"}, \"Body\": \"Added Comment\", \"Staff\" : \"Mary P.\", \"LastUpdated\":" + currentDateTime.ToString() + "}";

            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5001/comments")
            {
                Content = new StringContent(payload, Encoding.UTF8, "application/json")
            };
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                //var content = await response.Content.ReadAsStringAsync();               
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet()]
        public async Task<IActionResult> Discharge(int? id)
        {
            var currentDateTime = DateTime.UtcNow;

            var payload = "{\"Bed\": {\"Id\":" + id + "}, \"Patient\": {\"Id\": \"0083527\"}, \"Body\": \"Comment\", \"Staff\" : \"Mary P.\", \"LastUpdated\":" + currentDateTime.ToString() + "}";

            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5001/comments")
            {
                Content = new StringContent(payload, Encoding.UTF8, "application/json")
            };
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                //var content = await response.Content.ReadAsStringAsync();                
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
