using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CheapWare.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CheapWare.WebApp.Controllers
{
    public class CpusController : AServiceController
    {

        public CpusController(HttpClient httpClient) : base(httpClient)
        { }
        public async Task<ActionResult> Details(string name)
        {
            var request = CreateRequestToService(HttpMethod.Get, "api/cpus/" + name);

            try
            {
                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    TempData["statuscode"] = response.StatusCode;
                    return View("Error");
                }
                string jsonString = await response.Content.ReadAsStringAsync();

                Cpus cpu = JsonConvert.DeserializeObject<Cpus>(jsonString);

                return View(cpu);
                
            }
            catch (HttpRequestException)
            {
                return View("Error");
            }
        }
    }
}