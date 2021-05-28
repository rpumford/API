using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        HttpClient httpClient;
        static string API_KEY = "7Qsv1nFeIlmE3YbY90EfqvSeqNh8vhI5rlfXJITS";
        static string BASE_URL = "https://developer.nps.gov/api/v1/passportstamplocations";


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //Initialize API call
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string passportData = "";
            Root locations = null;

            string PASSPORT_PARKS_API_PATH = BASE_URL;
            httpClient.BaseAddress = new Uri(PASSPORT_PARKS_API_PATH);

            try
            {
                HttpResponseMessage response = httpClient.GetAsync(PASSPORT_PARKS_API_PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    passportData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
                if (!passportData.Equals(""))
                {
                    //JsonConvert part of NewtonSoft.Json Nuget package
                    locations = JsonConvert.DeserializeObject<Root>(passportData);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return View(locations);
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

