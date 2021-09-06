using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RomanNumbersApp.Models;

namespace RomanNumbersApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addAsync()
        {
            string num1 = HttpContext.Request.Form["txtFirst"].ToString();
            string num2 = HttpContext.Request.Form["txtSecond"].ToString();
            RomansRequest request = new RomansRequest() { value1 = num1,value2=num2 };
            string apiResponse = string.Empty;
            var dataAsString = JsonConvert.SerializeObject(request);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync("http://localhost:50504/" + "api/Romans", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        apiResponse = await response.Content.ReadAsStringAsync();
                    }
                    else
                    { apiResponse = "Please enter correct inputs!!"; }
                   
                }
            }
            ViewBag.SumResult = apiResponse;
            return View("Index");
        }
        public IActionResult sum()
        {
            return View();
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
